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
//            alert('s??? c??u kh?? / s??? c??u Trung b??nh / S??? C??u d??? ph???i l?? s??? Nguy??n D????NG ! OK ?')
//            $(this).val(0)
//            Hard = $('#HardQuestion').val();
//            Normal = $('#NormalQuestion').val();
//            Easy = $('#EasyQuestion').val();
//            Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
//            $('#TotalQuestion').val(Total);
//        } else if (Hard % 1 != 0 || Normal % 1 != 0 || Easy % 1 != 0) {
//            alert('s??? c??u kh?? / s??? c??u Trung b??nh / S??? C??u d??? ph???i l?? S??? Nguy??n D????ng ! OK ?')
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
//            alert('Th???y Ai REMAKE ??m ch??a :)) ng?????i ??m ph??? ??,S??? NGUY??N D????NG PLS')
//            $('#NumberOfRemake').val(0);
//        } else if (Remake % 1 != 0) {
//            alert('REMAKE 1 ph???n b??i ? realy ? :)) ??? ????y ch??ng t??i kh??ng l??m th??? , S??? NGUY??N D????NG PLS')
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
//            $('#WrongInputBank').html('<span>Ch???n Bank Pls</span>');
//        }
//        if ($(".RandomThi")[0].selectedIndex == 0) {
//            $('#WrongRandomThi').html('<span>Ch???n Lo???i random PLS</span>');
//        }
//        if ($(".Sday").val().length == 0) {
//            $('#WrongSday').html('<span>Ch???n Ng??y B???t ?????u PLS</span>');
//        }
//        if ($(".Eday").val().length == 0) {
//            $('#WrongEday').html('<span>Ch???n Ng??y K???t th??c PLS</span>');
//        }
//        if ($(".addKey").val().length == 0) {
//            $('#Wrongkey').html('<span>??i???n Key d??m c??i PLS</span>');
//        }
//        if ($(".addKey").val().length > 10) {
//            $('#Wrongkey').html('<span>Key 10 K?? t??? tr??? xu???ng thui</span>');
//        }
//        if ($(".addTime").val().length == 0) {
//            $('#WrongaddTime').html('<span>??i???n Th???i Gian Thi PLS</span>');
//        }
//        if ($("#TotalQuestion").val() == 0) {
//            $('#WrongQuestion').html('<p>???? T???o Quiz Th?? b??? Question v??o</p>');
//        }
//        if ($(".Inputclass").val() == '') {
//            $('#Wrongclass').html('<p>??i???n class v??o PLS</p>');
//        }
//        if ($(".Inputclass")[0].selectedIndex == 0) {
//            $('#Wrongclass').html('<p>Ch??? ch???n class Kh??ng ch???n ghi ch??</p>');
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
//        //    alert("K???t th??c cu???c ?????i tr?????c khi b???t ?????u ?? Ng??y B???t ?????u Tr?????c Ng??y K???t th??c ! OK ?")
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
//        //    alert("Vui l??ng nh???p l???n h??n ho???c b???ng ng??y hi???n t???i")
//        //    $(".Sday").val('')
//        //    $(".Eday").val('')
//        //} else if (parseInt(TotalSday) > parseInt(TotalEday)) {
//        //    alert("Ng??y b???t ?????u l???n h??n ng??y k???t th??c")
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
//            alert("Ng??y / Gi??? / Ph??t B???t ?????u Ho???c k???t th??c ph???i n???m ??? Hi???n t???i ho???c t????ng lai")
//            $(".Sday").val('')
//            $(".Eday").val('')
//        } else if (parseInt(TotalSday) > parseInt(TotalEday)) {
//            alert("Ng??y b???t ?????u ph???i l???n h??n ho???c b???ng ng??y k???t th??c")
//            $(".Sday").val('')
//            $(".Eday").val('')
//        }
//        else if (Sdayday = Edayday && SdayMonth == EdayMonth && SdayYear == EdayYear && Smin == Emin && Shours == Ehours) {
//            alert("Th???i gian K???t th??c ph???i l???n h??n th???i gian b???t ?????u")
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
//                    alert('Th???i gian m??? b??i thi ph???i l???n h??n th???i gian b??i thi');
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
//        alert("Key ph???i t??? 1 - 10 k?? t???.");
//        return false;
//    }
//}