/*=========================================================================================
    File Name: app-user-list.js
    Description: User List page
    --------------------------------------------------------------------------------------
    Item Name: Vuexy  - Vuejs, HTML & Laravel Admin Dashboard Template
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent

==========================================================================================*/

var dtUserTable = $('.user-list-table');

function editthisitiem(thisId, thisName, thisStatus) {
    $('#basic-icon-default-fullname-edit').val(thisName);
    $('#basic-icon-default-id').val(thisId);
    $('#id-edit-status').prop('checked', thisStatus==="1"?true:false);
    $('#id-edit-status').val(thisStatus);
    }
function inactivethisitiem(thisId, thisName) {

    $('#basic-icon-default-fullname-edit').val(thisName);
    $('#basic-icon-default-id').val(thisId);
    $('#idNameinactive').text(thisName);
    $('#idNameactive').text(thisName);
    $('#idNamedelete').text(thisName);
}
  
$(function () {
  ('use strict');


    newUserSidebar = $('.new-user-modal'),

        editUserSidebar = $('.edit-user-modal'),
        inactiveUserSidebar = $('.inactive-user-modal'),
        activeUserSidebar = $('.active-user-modal'),
        deleteUserSidebar = $('.delete-user-modal'),

    newUserForm = $('.add-new-user'),
        editUserForm = $('.edit-user'),
        inactiveUserForm = $('.inactive-user'),
        activeUserForm = $('.active-user'),
        deleteUserForm = $('.delete-user'),


    select = $('.select2'),
    dtContact = $('.dt-contact'),
    statusObj = {
      2: { title: 'Đang chờ', class: 'badge-light-warning' },
      1: { title: 'Đang dùng', class: 'badge-light-success' },
      0: { title: 'Tạm ngưng', class: 'badge-light-secondary' }
    };

  var assetPath = '../../../app-assets/',
    userView = 'app-user-view-account.html';

  if ($('body').attr('data-framework') === 'laravel') {
    assetPath = $('body').attr('data-asset-path');
    userView = assetPath + 'app/user/view/account';
  }




  select.each(function () {
    var $this = $(this);
    $this.wrap('<div class="position-relative"></div>');
    $this.select2({
      // the following code is used to disable x-scrollbar when click in select input and
      // take 100% width in responsive also
      dropdownAutoWidth: true,
      width: '100%',
      dropdownParent: $this.parent()
    });
  });

  // Users List datatable
  if (dtUserTable.length) {
    dtUserTable.DataTable({
      ajax: {
      url: apiUrl,
      type: "GET",
      headers: {
        "accept": "*/*",
          "authorization": authorization
      },
      dataSrc: function (json) {
        // Trả về danh sách items từ API
        return json.data.items.map(item => ({
          id: item.id,
          name: item.name,
          status: item.status ,//=== 1 ? "Active" : "Inactive",
          createdBy: item.createdBy?.fullName || "N/A",
          updatedBy: item.updatedBy?.fullName || "N/A",
          educationType: item.educationType?.name || "N/A",
          educationTypeId: item.educationType?.id || 0,
          createdAt: new Date(item.createdAt).toLocaleString(),
          updatedAt: new Date(item.updatedAt).toLocaleString()
        }));
      }
    },
    columns: [
      { data: "id", title: "ID" },
      { data: "name" },
      { data: "status", title: "Trạng thái" },
      { data: "createdBy", title: "Người tạo" },
      { data: "updatedBy", title: "Người sửa" },
      { data: "createdAt", title: "Ngày tạo" },
      { data: "updatedAt", title: "Ngày sửa" },
      { data: "", title: "Thao tác" }
    ],
     columnDefs: [
        {
          // For Responsive
          className: 'control',
          orderable: false,
          responsivePriority: 2,
          targets: 0,
          render: function (data, type, full, meta) {
            return '';
          }
        },
        {
          // User full name and username
          targets: 1,
          responsivePriority: 4,
          render: function (data, type, full, meta) {
            var $name = full['name'];
              var $educationType = full['educationType'];
           
            // Creates full output for row
              var $row_output =
                  '<div class="d-flex justify-content-left align-items-center">' +
                  
                  '<div class="d-flex flex-column">' +
                  '<span class="fw-bolder">' +
                  $name +
                  '</span>' +
                  '<small class="emp_post text-muted">' +
                  $educationType +
                  '</small>' +
                  '</div>' +
                  '</div>';
            return $row_output;
          }
        },       
       
        {
          // User Status
          targets: 2,
          render: function (data, type, full, meta) {
            var $status = full['status'];

            return (
              '<span class="badge rounded-pill ' +
              statusObj[$status].class +
              '" text-capitalized>' +
              statusObj[$status].title +
              '</span>'
            );
          }
        },
        {
          // Actions
          targets: -1,
          title: 'Actions',
          orderable: false,
            render: function (data, type, full, meta) {

                let intstt = full["status"];
                let stringChuyenTrangThai = "";
                if (intstt === 1) {
                    stringChuyenTrangThai = '<a onclick="inactivethisitiem(`' + full["id"] + '`,`' + full["name"] + '`)" class="dropdown-item edit-record" tabindex="0" aria-controls="DataTables_Table_0" type="button" data-bs-toggle="modal" data-bs-target="#modals-slide-in-inactive">' +
                        feather.icons['trash-2'].toSvg({ class: 'font-small-4 me-50' }) +
                        'Xóa</a>';
                }
                else {
                    stringChuyenTrangThai = '<a onclick="inactivethisitiem(`' + full["id"] + '`,`' + full["name"] + '`,)" class="dropdown-item edit-record" tabindex="0" aria-controls="DataTables_Table_0" type="button" data-bs-toggle="modal" data-bs-target="#modals-slide-in-active">' +
                        feather.icons['edit'].toSvg({ class: 'font-small-4 me-50' }) +
                        'Khôi phục</a>'
                        +
                        '<a onclick="inactivethisitiem(`' + full["id"] + '`,`' + full["name"] + '`)" class="dropdown-item edit-record" tabindex="0" aria-controls="DataTables_Table_0" type="button" data-bs-toggle="modal" data-bs-target="#modals-slide-in-delete">' +
                        feather.icons['trash-2'].toSvg({ class: 'font-small-4 me-50' }) +
                        'Xóa hết</a>';
                }
            return (
              '<div class="btn-group">' +
              '<a class="btn btn-sm dropdown-toggle hide-arrow" data-bs-toggle="dropdown">' +
              feather.icons['more-vertical'].toSvg({ class: 'font-small-4' }) +
              '</a>' + 
                '<div class="dropdown-menu dropdown-menu-end">' +
                
               '<a onclick="editthisitiem(`' + full["id"] + '`,`' + full["name"] + '`,`' + full["status"] +'`)" class="dropdown-item edit-record" tabindex="0" aria-controls="DataTables_Table_0" type="button" data-bs-toggle="modal" data-bs-target="#modals-slide-in-edit">' +
                feather.icons['edit'].toSvg({ class: 'font-small-4 me-50' }) +
              'Sửa</a>' +
                stringChuyenTrangThai
                + '  </div>' +
              '</div>' +
              '</div>'
            );
          }
        }
      ],
      order: [[1, 'desc']],
      dom:
        '<"d-flex justify-content-between align-items-center header-actions mx-2 row mt-75"' +
        '<"col-sm-12 col-lg-4 d-flex justify-content-center justify-content-lg-start" l>' +
        '<"col-sm-12 col-lg-8 ps-xl-75 ps-0"<"dt-action-buttons d-flex align-items-center justify-content-center justify-content-lg-end flex-lg-nowrap flex-wrap"<"me-1"f>B>>' +
        '>t' +
        '<"d-flex justify-content-between mx-2 row mb-1"' +
        '<"col-sm-12 col-md-6"i>' +
        '<"col-sm-12 col-md-6"p>' +
        '>',      
      // Buttons with Dropdown
      buttons: [
        {
          extend: 'collection',
          className: 'btn btn-outline-secondary dropdown-toggle me-2',
          text: feather.icons['external-link'].toSvg({ class: 'font-small-4 me-50' }) + 'Export',
          buttons: [
            {
              extend: 'print',
              text: feather.icons['printer'].toSvg({ class: 'font-small-4 me-50' }) + 'Print',
              className: 'dropdown-item',
              exportOptions: { columns: [1, 2, 3, 4, 5] }
            },
            {
              extend: 'csv',
              text: feather.icons['file-text'].toSvg({ class: 'font-small-4 me-50' }) + 'Csv',
              className: 'dropdown-item',
              exportOptions: { columns: [1, 2, 3, 4, 5] }
            },
            {
              extend: 'excel',
              text: feather.icons['file'].toSvg({ class: 'font-small-4 me-50' }) + 'Excel',
              className: 'dropdown-item',
              exportOptions: { columns: [1, 2, 3, 4, 5] }
            },
            {
              extend: 'pdf',
              text: feather.icons['clipboard'].toSvg({ class: 'font-small-4 me-50' }) + 'Pdf',
              className: 'dropdown-item',
              exportOptions: { columns: [1, 2, 3, 4, 5] }
            },
            {
              extend: 'copy',
              text: feather.icons['copy'].toSvg({ class: 'font-small-4 me-50' }) + 'Copy',
              className: 'dropdown-item',
              exportOptions: { columns: [1, 2, 3, 4, 5] }
            }
          ],
          init: function (api, node, config) {
            $(node).removeClass('btn-secondary');
            $(node).parent().removeClass('btn-group');
            setTimeout(function () {
              $(node).closest('.dt-buttons').removeClass('btn-group').addClass('d-inline-flex mt-50');
            }, 50);
          }
        },
        {
          text: 'Thêm mới',
          className: 'add-new btn btn-primary',
          attr: {
            'data-bs-toggle': 'modal',
            'data-bs-target': '#modals-slide-in'
          },
          init: function (api, node, config) {
            $(node).removeClass('btn-secondary');
          }
        }
      ],
      // For responsive popup
      responsive: {
        details: {
          display: $.fn.dataTable.Responsive.display.modal({
            header: function (row) {
              var data = row.data();
              return 'Details of ' + data['name'];
            }
          }),
          type: 'column',
          renderer: function (api, rowIdx, columns) {
            var data = $.map(columns, function (col, i) {
              return col.columnIndex !== 6 // ? Do not show row in modal popup if title is blank (for check box)
                ? '<tr data-dt-row="' +
                    col.rowIdx +
                    '" data-dt-column="' +
                    col.columnIndex +
                    '">' +
                    '<td>' +
                    col.title +
                    ':' +
                    '</td> ' +
                    '<td>' +
                    col.data +
                    '</td>' +
                    '</tr>'
                : '';
            }).join('');
            return data ? $('<table class="table"/>').append('<tbody>' + data + '</tbody>') : false;
          }
        }
      },
        language: {
            "sProcessing": "Đang tải...",
            "sLengthMenu": "Xem _MENU_ bản ghi",
            "sZeroRecords": "Data not updated yet!",
            "sInfo": "Đang xem từ _START_ đến _END_ trong _TOTAL_ bản ghi",
            "sInfoEmpty": "Không có dữ liệu",
            "sInfoFiltered": "(tìm trong _MAX_ bản ghi)",
            "sInfoPostFix": "",
            "sSearch": "Tìm kiếm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            }
        },
      initComplete: function () {
        // Adding role filter once table initialized
        this.api()
          .columns(3)
          .every(function () {
            var column = this;
            var label = $('<label class="form-label" for="UserRole">Người tạo</label>').appendTo('.user_role');
            var select = $(
              '<select id="UserRole" class="form-select text-capitalize mb-md-0 mb-2"><option value=""> Chọn </option></select>'
            )
              .appendTo('.user_role')
              .on('change', function () {
                var val = $.fn.dataTable.util.escapeRegex($(this).val());
                column.search(val ? '^' + val + '$' : '', true, false).draw();
              });

            column
              .data()
              .unique()
              .sort()
              .each(function (d, j) {
                select.append('<option value="' + d + '" class="text-capitalize">' + d + '</option>');
              });
          });
        // Adding plan filter once table initialized
        this.api()
          .columns(4)
          .every(function () {
            var column = this;
            var label = $('<label class="form-label" for="UserPlan">Người sửa</label>').appendTo('.user_plan');
            var select = $(
              '<select id="UserPlan" class="form-select text-capitalize mb-md-0 mb-2"><option value=""> Chọn </option></select>'
            )
              .appendTo('.user_plan')
              .on('change', function () {
                var val = $.fn.dataTable.util.escapeRegex($(this).val());
                column.search(val ? '^' + val + '$' : '', true, false).draw();
              });

            column
              .data()
              .unique()
              .sort()
              .each(function (d, j) {
                select.append('<option value="' + d + '" class="text-capitalize">' + d + '</option>');
              });
          });
        // Adding status filter once table initialized
        this.api()
          .columns(2)
          .every(function () {
            var column = this;
            var label = $('<label class="form-label" for="FilterTransaction">Trạng thái</label>').appendTo('.user_status');
            var select = $(
              '<select id="FilterTransaction" class="form-select text-capitalize mb-md-0 mb-2xx"><option value=""> Chọn </option></select>'
            )
              .appendTo('.user_status')
              .on('change', function () {
                var val = $.fn.dataTable.util.escapeRegex($(this).val());
                column.search(val ? '^' + val + '$' : '', true, false).draw();
              });

            column
              .data()
              .unique()
              .sort()
              .each(function (d, j) {
                select.append(
                  '<option value="' +
                    statusObj[d].title +
                    '" class="text-capitalize">' +
                    statusObj[d].title +
                    '</option>'
                );
              });
          });
      }
    });
  }

  // Form Validation
  if (newUserForm.length) {
    newUserForm.validate({
      errorClass: 'error',
      rules: {
        'user-fullname': {
          required: true
        },
        },
        messages: {
            'user-fullname': {
                required: "Vui lòng nhập tên Trường"
            },
        }
    });

    newUserForm.on('submit', function (e) {
      var isValid = newUserForm.valid();
      e.preventDefault();
        if (isValid) {
            let dataName = $('#basic-icon-default-fullname').val();
            $.ajax({
                url: fullApiLink,
                type: 'POST',
                headers: {
                    "authorization": authorization,
                    "Content-Type": "application/json"
                },
                data: JSON.stringify({ name: dataName }), // Chuyển dữ liệu sang JSON
                success: function (response) {
                    // Hiển thị thông báo thành công
                    // $('#responseMessage').text('School added successfully!');
                    // console.log('Success:', response);
                    dtUserTable.DataTable().ajax.reload();
                    $('#basic-icon-default-fullname').val("");
                    newUserSidebar.modal('hide');

                },
                error: function (error) {
                    // Hiển thị lỗi nếu có
                    //  $('#responseMessage').text('Error adding school.');
                    // console.error('Error:', error);
                }
            });


      }
    });
  }


    if (editUserForm.length) {
        editUserForm.validate({
      errorClass: 'error',
      rules: {
        'user-fullname': {
          required: true
        },
        },
        messages: {
            'user-fullname': {
                required: "Vui lòng nhập tên Trường"
            },
        }
    });

    editUserForm.on('submit', function (e) {
        var isValid = editUserForm.valid();
      e.preventDefault();
        if (isValid) {
            let dataName = $('#basic-icon-default-fullname-edit').val();
            let thisId = $('#basic-icon-default-id').val();
            let datastatus = $('#id-edit-status').is(":checked")?1:0;
            $.ajax({
                url: fullApiLink+"/"+thisId,
                type: 'PATCH',
                headers: {
                    "authorization": authorization,
                    "Content-Type": "application/json"
                },
                data: JSON.stringify({ name: dataName, status: datastatus }), // Chuyển dữ liệu sang JSON
                success: function (response) {
                    // Hiển thị thông báo thành công
                    // $('#responseMessage').text('School added successfully!');
                    // console.log('Success:', response);
                    dtUserTable.DataTable().ajax.reload();
                    editUserSidebar.modal('hide');
                },
                error: function (error) {
                    // Hiển thị lỗi nếu có
                    //  $('#responseMessage').text('Error adding school.');
                    // console.error('Error:', error);
                }
            });


      }
    });
  }


    if (inactiveUserForm.length) {


        inactiveUserForm.on('submit', function (e) {
            e.preventDefault();

            let dataName = $('#basic-icon-default-fullname-edit').val();
            let thisId = $('#basic-icon-default-id').val();
            let datastatus = 0;
            $.ajax({
                url: fullApiLink + "/" + thisId,
                type: 'PATCH',
                headers: {
                    "authorization": authorization,
                    "Content-Type": "application/json"
                },
                data: JSON.stringify({ name: dataName, status: datastatus }), // Chuyển dữ liệu sang JSON
                success: function (response) {
                    // Hiển thị thông báo thành công
                    // $('#responseMessage').text('School added successfully!');
                    // console.log('Success:', response);
                    dtUserTable.DataTable().ajax.reload();
                    inactiveUserSidebar.modal('hide');
                },
                error: function (error) {
                    // Hiển thị lỗi nếu có
                    //  $('#responseMessage').text('Error adding school.');
                    // console.error('Error:', error);
                }
            });



        });
    }

    if (activeUserForm.length) {


        activeUserForm.on('submit', function (e) {
            e.preventDefault();

            let dataName = $('#basic-icon-default-fullname-edit').val();
            let thisId = $('#basic-icon-default-id').val();
            let datastatus = 1;
            $.ajax({
                url: fullApiLink + "/" + thisId,
                type: 'PATCH',
                headers: {
                    "authorization": authorization,
                    "Content-Type": "application/json"
                },
                data: JSON.stringify({ name: dataName, status: datastatus }), // Chuyển dữ liệu sang JSON
                success: function (response) {
                    // Hiển thị thông báo thành công
                    // $('#responseMessage').text('School added successfully!');
                    // console.log('Success:', response);
                    dtUserTable.DataTable().ajax.reload();
                    activeUserSidebar.modal('hide');
                },
                error: function (error) {
                    // Hiển thị lỗi nếu có
                    //  $('#responseMessage').text('Error adding school.');
                    // console.error('Error:', error);
                }
            });



        });
    }

    if (deleteUserForm.length) {


        deleteUserForm.on('submit', function (e) {
            e.preventDefault();

            let thisId = $('#basic-icon-default-id').val();
            let datastatus = 1;
            $.ajax({
                url: fullApiLink + "/" + thisId,
                type: 'DELETE',
                headers: {
                    "authorization": authorization,
                    "Content-Type": "application/json"
                },
                success: function (response) {
                    // Hiển thị thông báo thành công
                    // $('#responseMessage').text('School added successfully!');
                    // console.log('Success:', response);
                    dtUserTable.DataTable().ajax.reload();
                    deleteUserSidebar.modal('hide');
                },
                error: function (error) {
                    // Hiển thị lỗi nếu có
                    //  $('#responseMessage').text('Error adding school.');
                    // console.error('Error:', error);
                }
            });



        });
    }


  // Phone Number
  if (dtContact.length) {
    dtContact.each(function () {
      new Cleave($(this), {
        phone: true,
        phoneRegionCode: 'US'
      });
    });
  }
});




