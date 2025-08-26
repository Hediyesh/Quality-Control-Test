$(document).ready(function () {
    $(document).on('change', '#mySelectCompany', function () {
        const companyId = $(this).val();
        getCompanyCatsMachines(companyId);
    });
    function getCompanyCatsMachines(companyid) {
        $.ajax({
            url: '/Admin/Products/UpdateMachinesCategoriesByCompany',
            type: 'GET',
            data: { id: companyid },
            success: function (response) {
                updateCategoryDropdown(response.categories);
                updateMachinesDropdown(response.machines);
            },
            error: function () {
                alert('خطا در واکشی اطلاعات دسته‌بندی و دستگاه‌ها');
            }
        });
    }

    function updateCategoryDropdown(categories) {
        const $categorySelect = $('#mySelectCategory');
        $categorySelect.empty();
        $categorySelect.append($('<option></option>'));

        if (categories && categories.length > 0) {
            categories.forEach(item => {
                $categorySelect.append(
                    $('<option></option>').val(item.categoryId).text(item.categoryName)
                );
            });
        }

        $categorySelect.trigger('change.select2');
    }

    function updateMachinesDropdown(machines) {
        const $machineSelect = $('#mySelectMachines');
        $machineSelect.empty();

        if (machines && machines.length > 0) {
            machines.forEach(item => {
                $machineSelect.append(
                    $('<option></option>').val(item.machineId).text(item.machineName)
                );
            });
        }

        $machineSelect.trigger('change.select2');
    }
});

document.addEventListener("DOMContentLoaded", function () {
    updateHiddenInput("selectedMachinesTableBody", "machineHiddenInput");

    const companyInput = document.getElementById("userCompanyId");
    const categoryInput = document.getElementById("categoryName");

    const companyId = companyInput?.value;

    if (companyId) {
        categoryInput.disabled = false;
        fetchCategoriesByCompanyId(companyId);
    } else {
        categoryInput.disabled = true;
    }

    // همچنین اگه شرکت انتخاب شد بعداً (مثلاً تو دراپ‌دان بود)، اینم اضافه کن:
    companyInput.addEventListener('change', function () {
        const selectedCompanyId = this.value;
        if (selectedCompanyId) {
            categoryInput.disabled = false;
            fetchCategoriesByCompanyId(selectedCompanyId);
        } else {
            categoryInput.disabled = true;
        }
    });
});

//for cat select
function filterDropdown(input) {
    const dropdownId = input.getAttribute('data-dropdown-id');
    const dropdown = document.getElementById(dropdownId);
    const filter = input.value.toLowerCase();

    Array.from(dropdown.children).forEach(option => {
        const text = option.textContent.toLowerCase();
        option.style.display = text.includes(filter) ? 'block' : 'none';
    });

    dropdown.style.display = 'block';
}
function showDropdown(input) {
    const dropdownId = input.getAttribute('data-dropdown-id');
    document.getElementById(dropdownId).style.display = 'block';
}
function selectOption(element, hiddenInputId) {
    const value = element.getAttribute("data-value");
    const text = element.textContent;
    const input = document.querySelector(`input[data-dropdown-id="${element.parentElement.id}"]`);
    const hiddenInput = document.getElementById(hiddenInputId);

    input.value = text;
    hiddenInput.value = value;

    // اگر شرکت انتخاب شد، دسته‌بندی‌ها را واکشی کن
    if (hiddenInputId === 'companyInput') {
        fetchCategoriesByCompanyId(value);
    }

    // بستن منو
    element.parentElement.style.display = 'none';
}

document.addEventListener('click', function (event) {
    // بستن تمام .dropdown-options
    document.querySelectorAll('.dropdown-search').forEach(function (dropdown) {
        const options = dropdown.querySelector('.dropdown-options');
        if (!dropdown.contains(event.target)) {
            options.style.display = 'none';
        }
    });

    // بستن تمام .multi-options
    document.querySelectorAll('.multi-dropdown').forEach(function (dropdown) {
        const options = dropdown.querySelector('.multi-options');
        if (!dropdown.contains(event.target)) {
            options.style.display = 'none';
        }
    });
});

//for machine select
function showMultiDropdown(input) {
    const dropdownId = input.getAttribute("data-dropdown-id");
    document.getElementById(dropdownId).style.display = "block";
}

function filterMultiDropdown(input) {
    const value = input.value.toLowerCase();
    const dropdownId = input.getAttribute("data-dropdown-id");
    const options = document.getElementById(dropdownId).children;

    Array.from(options).forEach(opt => {
        const text = opt.getAttribute("data-text").toLowerCase();
        opt.style.display = text.includes(value) ? "block" : "none";
    });
}

function selectMultiOption(option, tableBodyId, hiddenInputId) {
    const machineId = option.getAttribute("data-value");
    const machineName = option.getAttribute("data-text");
    const tableBody = document.getElementById(tableBodyId);

    // جلوگیری از تکرار
    if (document.querySelector(`#${tableBodyId} tr[data-id="${machineId}"]`)) return;

    // اضافه کردن سطر
    const row = document.createElement("tr");
    row.setAttribute("data-id", machineId);
    row.innerHTML = `
            <td>${machineName}</td>
            <td><button type="button" class="btn btn-danger btn-sm" onclick="removeMachineRow('${machineId}', '${tableBodyId}', '${hiddenInputId}')">حذف</button></td>
                        `;
    tableBody.appendChild(row);

    // به‌روزرسانی hidden input
    updateHiddenInput(tableBodyId, hiddenInputId);

    // بستن dropdown
    option.parentElement.style.display = "none";
}

function removeMachineRow(machineId, tableBodyId, hiddenInputId) {
    const row = document.querySelector(`#${tableBodyId} tr[data-id="${machineId}"]`);
    if (row) row.remove();
    updateHiddenInput(tableBodyId, hiddenInputId);
}

function updateHiddenInput(tableBodyId, hiddenInputId) {
    const rows = document.querySelectorAll(`#${tableBodyId} tr`);
    const ids = Array.from(rows).map(row => row.getAttribute("data-id"));
    document.getElementById(hiddenInputId).value = ids.join(",");
}

function showDropdown(input) {
    const dropdownId = input.getAttribute('data-dropdown-id');
    const dropdown = document.getElementById(dropdownId);
    dropdown.style.display = 'block';
}

function filterDropdown(input) {
    const dropdownId = input.getAttribute('data-dropdown-id');
    const filter = input.value.toLowerCase();
    const dropdown = document.getElementById(dropdownId);
    const items = dropdown.querySelectorAll('div');

    items.forEach(function (item) {
        const text = item.textContent.toLowerCase();
        item.style.display = text.includes(filter) ? 'block' : 'none';
    });
}

// function DeleteProduct(id){
//      $("#DeleteModal").modal('show');
// }
function DeleteProduct(id) {
    if (!confirm("آیا از حذف این محصول اطمینان دارید؟")) return;

    $.ajax({
        url: '/Admin/Products/DeleteProduct/' + id,
        type: 'DELETE',
        success: function (res) {
            alert("✅ " + res);
            $("#" + id).remove(); // حذف ردیف از جدول
        },
        error: function (xhr) {
            alert("❌ خطا در حذف: " + xhr.responseText);
        }
    });
}

function EditProduct(id) {
    $("#ModalBody").load("/Admin/Products/EditOrCreatePartial?id=" + id, function () {
        $("#ProductModal").modal("show");
        document.getElementById("DoBtn").innerHTML = "اعمال تغییرات";
        document.getElementById("ModalHead").innerHTML = "ویرایش محصول";
        let categoryId = document.getElementById("proCategoryInput").value;
        let companyId = document.getElementById("proCompanyInput").value;

        // اول مقدار رو ست کن
        $('#mySelectCompany').val(companyId).trigger('change');
        $('#mySelectCategory').val(categoryId).trigger('change');

        // بعد select2 بساز
        $('#mySelectCompany').select2({
            placeholder: 'انتخاب شرکت',
            minimumResultsForSearch: 0,
            width: '100%',
            dir: 'rtl'
        });
        $('#mySelectCategory').select2({
            placeholder: 'انتخاب دسته‌بندی',
            minimumResultsForSearch: 0,
            width: '100%',
            dir: 'rtl'
        });
        if ($('#mySelectMachines').hasClass("select2-hidden-accessible")) {
            $('#mySelectMachines').select2('destroy');
        }
        $('#mySelectMachines').select2({
            placeholder: 'انتخاب دستگاه',
            minimumResultsForSearch: 0,
            allowClear: true,
            width: '100%',
            dir: 'rtl'
        });

        // مقدار اولیه hidden input بعد از لود کامل select2
        $('#SelectedMachineIds').val($('#mySelectMachines').val().join(','));

        // موقع تغییر انتخاب‌ها، آی‌دی‌ها رو توی input hidden بریز
        $('#mySelectMachines').on('change', function () {
            var selectedIds = $(this).val(); // آرایه
            $('#SelectedMachineIds').val(selectedIds ? selectedIds.join(',') : '');
        });
    });
    document.getElementById("productCreateEdit").value = id;
}


function CreateProduct() {
    $("#ModalBody").load("/Admin/Products/EditOrCreatePartial", function () {
        $("#ProductModal").modal("show");
        document.getElementById("DoBtn").innerHTML = "ایجاد";
        document.getElementById("ModalHead").innerHTML = "ایجاد محصول جدید";
        $('#mySelectCompany').select2({
            placeholder: 'انتخاب شرکت',
            minimumResultsForSearch: 0,
            width: '100%',
            dir: 'rtl'
        });
        $('#mySelectCategory').select2({
            placeholder: 'انتخاب دسته‌بندی',
            minimumResultsForSearch: 0,
            width: '100%',
            dir: 'rtl'
        });
        if ($('#mySelectMachines').hasClass("select2-hidden-accessible")) {
            $('#mySelectMachines').select2('destroy');
        }
        $('#mySelectMachines').select2({
            placeholder: 'انتخاب دستگاه',
            minimumResultsForSearch: 0,
            allowClear: true,
            width: '100%',
            dir: 'rtl'
        });
        // مقدار اولیه‌ی hidden input بعد از لود کامل select2
        $('#SelectedMachineIds').val($('#mySelectMachines').val().join(','));

        // موقع تغییر انتخاب‌ها، آی‌دی‌ها رو توی input hidden بریز
        $('#mySelectMachines').on('change', function () {
            var selectedIds = $(this).val(); // این میشه یه آرایه از value های انتخاب شده
            $('#SelectedMachineIds').val(selectedIds ? selectedIds.join(',') : '');
        });
    });
    document.getElementById("productCreateEdit").value = "";
}
function CloseProductModal() {
    $("#ProductModal").modal('hide');
}
//function CloseDeleteModal() {
//    $("#DeleteModal").modal('hide');
//}
function EditOrCreateProduct() {
    const pid = document.getElementById("ProductId").value;
    const productName = document.getElementById("productName").value;
    const categoryId = $('#mySelectCategory').val();
    const companyId = $('#mySelectCompany').val() || document.getElementById("userCompanyNameInput")?.value;
    const selectedMachineIds = $('#mySelectMachines').val() || [];

    const data = {
        productName: productName,
        categoryId: parseInt(categoryId),
        companyId: parseInt(companyId),
        machines: selectedMachineIds.map(id => parseInt(id))
    };

    if (!pid) {
        // Create
        $.ajax({
            url: '/Admin/Products/AddProduct/',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (res) {
                alert(res); // پیام موفقیت
                window.location.reload();
            },
            error: function (xhr) {
                alert("❌ خطا: " + xhr.responseText); // پیام خطا از BadRequest
            }
        });
    } else {
        // Edit
        $.ajax({
            url: '/Admin/Products/EditProduct/' + pid,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (res) {
                alert("✅ " + res);
                window.location.reload();
            },
            error: function (xhr) {
                alert("❌ خطا: " + xhr.responseText);
            }
        });
    }
}