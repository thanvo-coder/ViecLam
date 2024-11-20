/*=========================================================================================
  File Name: auth-login.js
  Description: Auth login js file.
  ----------------------------------------------------------------------------------------
  Item Name: Vuexy  - Vuejs, HTML & Laravel Admin Dashboard Template
  Author: PIXINVENT
  Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

$(function () {
  'use strict';

  var pageLoginForm = $('.auth-login-form');

  // jQuery Validation
  // --------------------------------------------------------------------
  if (pageLoginForm.length) {
    pageLoginForm.validate({
      /*
      * ? To enable validation onkeyup
      onkeyup: function (element) {
        $(element).valid();
      },*/
      /*
      * ? To enable validation on focusout
      onfocusout: function (element) {
        $(element).valid();
      }, */
      rules: {
        'login-email': {
              required: true,
          //email: true
        },
        'login-password': {
          required: true
        }
        },
        messages: {
            'login-email': {
                required: "Vui lòng nhập email của bạn." 
            },
            'login-password': {
                required: "Vui lòng nhập mật khẩu."
            }
        }
        ,
        submitHandler: function (form) {
            loading(1);

            $.ajax({
                type: "POST",
                url: "/System/CheckLogin",
                data: { uname: $('#login-email').val(), passw: $('#login-password').val() },
                success: function (response) {

                    loading(0);
                    switch (response.result) {
                        case 1:
                            $('#login-thongbao').html("<span style='color: red;'>Không thành công. Vui lòng kiểm tra lại</span>");
                            setTimeout(tatThongBao,2000);
                            break;
                        case 0:
                            window.location.href = $('#login-returnUrl').val();
                            break;
                        default:
                            break;
                    }
                },
                failure: function (response) {
                    loading(0);
                    $('#login-thongbao').text("Đăng nhập không thành công. Vui lòng kiểm tra lại");
                },
                error: function (response) {
                    loading(0);
                    $('#login-thongbao').text("Đăng nhập không thành công. Vui lòng kiểm tra lại");
                }
            });
        }

    });
  }
});


function loading() {

}

function tatThongBao() {

    $('#login-thongbao').html("Đăng nhập vào tài khoản đã đăng ký");
}