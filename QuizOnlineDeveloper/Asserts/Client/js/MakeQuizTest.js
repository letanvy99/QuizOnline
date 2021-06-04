//$(document).ready(function () {
//    var Hard = $('#HardQuestion').val();
//    var Normal = $('#NormalQuestion').val();
//    var Easy = $('#EasyQuestion').val();
//    var Total


//    $('.minus').click(function (e) {
//        e.preventDefault();
//        var quality = $(this).parent().find('input');
//        var qty = quality.val();
//        var value = parseInt(qty);
//        if (value >= 1) {
//            value = value - 1;
//        } else {
//            value = 0;
//        }
//        quality.val(value)
//        Hard = $('#HardQuestion').val();
//        Normal = $('#NormalQuestion').val();
//        Easy = $('#EasyQuestion').val();
//        Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
//        $('#TotalQuestion').val(Total);
//    });
//    $('.plush').click(function (e) {
//        e.preventDefault();
//        var quality = $(this).parent().find('input');
//        var qty = quality.val();
//        var value = parseInt(qty);
//        if (value >= 0) {
//            value = value + 1;
//        } else {
//            value = 0;
//        }
//        quality.val(value)
//        Hard = $('#HardQuestion').val();
//        Normal = $('#NormalQuestion').val();
//        Easy = $('#EasyQuestion').val();
//        Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
//        $('#TotalQuestion').val(Total);
//    });
//    $('.reset').click(function (e) {
//        e.preventDefault();
//        $('.InputBank').val('');
//        $('.cart-page').find('input').val('');
//        $('.quantity-box').find('input').val(0);
//        $('.CreateBtn').find('input').val('Create Quiz')
//    });
//    $('.Keyjoin').click(function (e) {
//        e.preventDefault();
//        $('.cart-row').html('');
//    });

//    $('#HardQuestion,#NormalQuestion,#EasyQuestion').blur(function (e) {
//        e.preventDefault();
//        Hard = $('#HardQuestion').val();
//        Normal = $('#NormalQuestion').val();
//        Easy = $('#EasyQuestion').val();
//        if (Hard < 0 || Normal < 0 || Easy < 0) {
//            alert('số câu khó / số câu Trung bình / Số Câu dễ phải là số Nguyên DƯƠNG ! OK ?')
//            $(this).val(0)
//            Hard = $('#HardQuestion').val();
//            Normal = $('#NormalQuestion').val();
//            Easy = $('#EasyQuestion').val();
//            Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
//            $('#TotalQuestion').val(Total);
//        } else if (Hard % 1 != 0 || Normal % 1 != 0 || Easy % 1 != 0) {
//            alert('số câu khó / số câu Trung bình / Số Câu dễ phải là Số Nguyên Dương ! OK ?')
//            $(this).val(0)
//            Hard = $('#HardQuestion').val();
//            Normal = $('#NormalQuestion').val();
//            Easy = $('#EasyQuestion').val();
//            Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
//            $('#TotalQuestion').val(Total);
//        } else {
//            Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
//            $('#TotalQuestion').val(Total);
//        }
//    });
//    $('#NumberOfRemake').blur(function (e) {
//        var Remake = $('#NumberOfRemake').val();
//        if (Remake < 0) {
//            alert('Thấy Ai REMAKE âm chưa :)) người âm phủ à,Số NGUYÊN DƯƠNG PLS')
//            $('#NumberOfRemake').val(0);
//        } else if (Remake % 1 != 0) {
//            alert('REMAKE 1 phần bài ? realy ? :)) Ở đây chúng tôi không làm thế , Số NGUYÊN DƯƠNG PLS')
//            $('#NumberOfRemake').val(0);
//        }
//    });
//    $('#SubmitAndCheck').click(function (e) {
//        e.preventDefault();
//        $('#WrongNameQuiz span').remove();
//        $('#WrongInputBank span').remove();
//        $('#WrongRandomThi span').remove();
//        $('#WrongSday span').remove();
//        $('#WrongEday span').remove();
//        $('#Wrongkey span').remove();
//        $('#WrongaddTime span').remove();
//        $('#WrongQuestion p').remove();
//        $('#Wrongclass p').remove();


//        if ($('#NameQuiz').val().length == 0) {
//            $('#WrongNameQuiz').html('<span>Enter Name Quiz</span>');
//        }
//        if ($(".InputBank")[0].selectedIndex == 0) {
//            $('#WrongInputBank').html('<span>Chọn Bank Pls</span>');
//        }
//        if ($(".RandomThi")[0].selectedIndex == 0) {
//            $('#WrongRandomThi').html('<span>Chọn Loại random PLS</span>');
//        }
//        if ($(".Sday").val().length == 0) {
//            $('#WrongSday').html('<span>Chọn Ngày Bắt Đầu PLS</span>');
//        }
//        if ($(".Eday").val().length == 0) {
//            $('#WrongEday').html('<span>Chọn Ngày Kết thúc PLS</span>');
//        }
//        if ($(".addKey").val().length == 0) {
//            $('#Wrongkey').html('<span>Điền Key dùm cái PLS</span>');
//        }
//        if ($(".addKey").val().length > 10) {
//            $('#Wrongkey').html('<span>Key 10 Kí tự trở xuống thui</span>');
//        }
//        if ($(".addTime").val().length == 0) {
//            $('#WrongaddTime').html('<span>Điền Thời Gian Thi PLS</span>');
//        }
//        if ($("#TotalQuestion").val() == 0) {
//            $('#WrongQuestion').html('<p>Đã Tạo Quiz Thì bỏ Question vào</p>');
//        }
//        if ($(".Inputclass").val() == '') {
//            $('#Wrongclass').html('<p>Điền class vào PLS</p>');
//        }
//        if ($(".Inputclass")[0].selectedIndex == 0) {
//            $('#Wrongclass').html('<p>Chỉ chọn class Không chọn ghi chú</p>');
//        }
//        if ($('#NameQuiz').val().length != 0 && $(".InputBank")[0].selectedIndex != 0 && $(".RandomThi")[0].selectedIndex != 0 &&
//            $(".Sday").val().length != 0 && $(".Eday").val().length != 0 && $(".addKey").val().length != 0 && $(".addTime").val().length != 0 && $("#TotalQuestion").val() != 0 && $(".Inputclass").val() != '' && $(".Inputclass")[0].selectedIndex != 0) {
//            $("#shadowbox").show(300)
//            $("#Addsucces").show(600);
//        }
//    });
//    $('.Sday,.Eday').blur(function (e) {
//        var stringSday = $(".Sday").val()
//        var Smin = stringSday.slice(14, 16);
//        var Shours = stringSday.slice(11, 13);
//        var Sdayday = stringSday.slice(8, 10);
//        var SdayMonth = stringSday.slice(5, 7);
//        var SdayYear = stringSday.slice(0, 4);
//        var TotalSday = SdayYear + SdayMonth + Sdayday + Shours + Smin

//        var stringEday = $(".Eday").val()
//        var Emin = stringEday.slice(14, 16);
//        var Ehours = stringEday.slice(11, 13);
//        var Edayday = stringEday.slice(8, 10);
//        var EdayMonth = stringEday.slice(5, 7);
//        var EdayYear = stringEday.slice(0, 4);
//        var TotalEday = EdayYear + EdayMonth + Edayday + Ehours + Emin
//        //if (parseInt(TotalSday) > parseInt(TotalEday)) {
//        //    alert("Kết thúc cuộc đời trước khi bắt đầu ?? Ngày Bắt Đầu Trước Ngày Kết thúc ! OK ?")
//        //    $(".Sday").val('')
//        //    $(".Eday").val('')
//        //}
//        //-------------------------------------//
//        //var currentdate = new Date();
//        //var CurentDay = currentdate.getDate();
//        //var CurentMonth = parseInt(currentdate.getMonth() + 1);
//        //if (CurentMonth < 10) {
//        //    CurentMonth = 0 + CurentMonth.toString()
//        //} else {
//        //    CurentMonth = CurentMonth;
//        //}
//        //var CurentYear = currentdate.getFullYear();
//        //var TotalCurentday = CurentDay.toString() + CurentMonth.toString() + CurentYear.toString()

//        //if (parseInt(TotalCurentday) > parseInt(TotalSday) || parseInt(TotalCurentday) > parseInt(TotalEday)) {
//        //    alert("Vui lòng nhập lớn hơn hoặc bằng ngày hiện tại")
//        //    $(".Sday").val('')
//        //    $(".Eday").val('')
//        //} else if (parseInt(TotalSday) > parseInt(TotalEday)) {
//        //    alert("Ngày bắt đầu lớn hơn ngày kết thúc")
//        //    $(".Sday").val('')
//        //    $(".Eday").val('')
//        //}
//        //-------------------------------------//
//        var currentdate = new Date();

//        var curentMin = currentdate.getMinutes();
//        if (curentMin < 10) {
//            curentMin = 0 + curentMin.toString()
//        } else {
//            curentMin = curentMin;
//        }

//        var curentHours = currentdate.getHours();
//        if (curentHours < 10) {
//            curentHours = 0 + curentHours.toString()
//        } else {
//            curentHours = curentHours;
//        }

//        var CurentDay = currentdate.getDate();
//        if (CurentDay < 10) {
//            CurentDay = 0 + CurentDay.toString()
//        } else {
//            CurentDay = CurentDay;
//        }

//        var CurentMonth = parseInt(currentdate.getMonth() + 1);
//        if (CurentMonth < 10) {
//            CurentMonth = 0 + CurentMonth.toString()
//        } else {
//            CurentMonth = CurentMonth;
//        }

//        var CurentYear = currentdate.getFullYear();
//        var TotalCurentday = CurentYear.toString() + CurentMonth.toString() + CurentDay.toString() + curentHours.toString() + curentMin.toString()


//        if (parseInt(TotalCurentday) > parseInt(TotalSday) || parseInt(TotalCurentday) > parseInt(TotalEday)) {
//            alert("Ngày / Giờ / Phút Bắt đầu Hoặc kết thúc phải nằm ở Hiện tại hoặc tương lai")
//            $(".Sday").val('')
//            $(".Eday").val('')
//        } else if (parseInt(TotalSday) > parseInt(TotalEday)) {
//            alert("Ngày bắt đầu phải lớn hơn hoặc bằng ngày kết thúc")
//            $(".Sday").val('')
//            $(".Eday").val('')
//        }
//        else if (Sdayday = Edayday && SdayMonth == EdayMonth && SdayYear == EdayYear && Smin == Emin && Shours == Ehours) {
//            alert("Thời gian Kết thúc phải lớn hơn thời gian bắt đầu")
//            $(".Eday").val('')
//        } 

//        $('.addTime').blur(function (e) {
//            e.preventDefault();
//            var stringSday = $(".Sday").val()
//            var Smin = stringSday.slice(14, 16);
//            var Shours = stringSday.slice(11, 13);
//            var Sdayday = stringSday.slice(8, 10);
//            var SdayMonth = stringSday.slice(5, 7);
//            var SdayYear = stringSday.slice(0, 4);
//            var stringEday = $(".Eday").val()
//            var Emin = stringEday.slice(14, 16);
//            var Ehours = stringEday.slice(11, 13);
//            var Edayday = stringEday.slice(8, 10);
//            var EdayMonth = stringEday.slice(5, 7);
//            var EdayYear = stringEday.slice(0, 4);
//            var TimeOpen = ((Ehours - Shours) * 60) + (Emin - Smin);
//            if (Sdayday == Edayday && SdayMonth == EdayMonth && SdayYear == EdayYear) {
//                if (parseInt($('.addTime').val()) > TimeOpen) {
//                    alert('Thời gian mở bài thi phải lớn hơn thời gian bài thi');
//                    $('.addTime').val('');
//                }
//            }
//        });
//    });
//}); 

//$('.check-outBtn').click(function (e) {
//    e.preventDefault();
//    $('.quantity-box').find('input').val();
//    $('.InputName').val();
//    $('.InputBank').val();
//});

//function validateform() {
//    var key = document.myform.key.value;

//    if (key == null) {
//        alert("Name can't be blank");
//        return false;
//    } else if (key.length > 10 || key.length <= 1) {
//        alert("Key phải từ 1 - 10 kí tự.");
//        return false;
//    }
//}