#!/bin/sh

# --- تنظیمات اولیه ---
set -e  # اگر هر دستوری خطا داد، اسکریپت متوقف بشه

# --- تابع انتظار برای سرویس ---
wait_for_service() {
  local host="$1"
  local port="$2"
  local service_name="$3"
  echo "⏳ در حال انتظار برای آماده‌شدن $service_name ($host:$port)..."

  while ! nc -z "$host" "$port"; do
    echo "🔴 $service_name هنوز آماده نیست. صبر می‌کنم..."
    sleep 3
  done

  echo "🟢 $service_name آماده شد!"
}

# --- انتظار برای وابستگی‌ها ---
# می‌تونی بیشتر هم اضافه کنی (مثلاً دیتابیس)
wait_for_service "rabbitmq" "5672" "RabbitMQ"

# --- پیدا کردن و اجرای اولین فایل .dll ---
# فرض: فقط یک فایل .dll در /app وجود داره (مثل ControlWebAPI.dll)
APP_DLL=$(find /app -maxdepth 1 -name "*.dll" -type f | head -n 1)

if [ -z "$APP_DLL" ]; then
  echo "❌ هیچ فایل .dllی در /app پیدا نشد! مطمئن شو پابلیش شده باشه."
  exit 1
fi

echo "🚀 در حال اجرای برنامه: $(basename $APP_DLL)"
exec dotnet "$APP_DLL"