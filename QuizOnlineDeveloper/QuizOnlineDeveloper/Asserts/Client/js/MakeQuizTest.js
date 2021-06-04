$(document).ready(function() {
    var Hard = $('#HardQuestion').val();
    var Normal = $('#NormalQuestion').val();
    var Easy = $('#EasyQuestion').val();
    var Total



    $('.minus').click(function(e) {
        e.preventDefault();
        var quality = $(this).parent().find('input');
        var qty = quality.val();
        var value = parseInt(qty);
        if (value >= 1) {
            value = value - 1;
        } else {
            value = 0;
        }
        quality.val(value)
        Hard = $('#HardQuestion').val();
        Normal = $('#NormalQuestion').val();
        Easy = $('#EasyQuestion').val();
        Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
        $('#TotalQuestion').val(Total);
    });
    $('.plush').click(function(e) {
        e.preventDefault();
        var quality = $(this).parent().find('input');
        var qty = quality.val();
        var value = parseInt(qty);
        if (value >= 0) {
            value = value + 1;
        } else {
            value = 0;
        }
        quality.val(value)
        Hard = $('#HardQuestion').val();
        Normal = $('#NormalQuestion').val();
        Easy = $('#EasyQuestion').val();
        Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
        $('#TotalQuestion').val(Total);
    });
    $('.reset').click(function(e) {
        e.preventDefault();
        $('.InputBank').val('');
        $('.cart-page').find('input').val('');
        $('.quantity-box').find('input').val(0);
        $('.CreateBtn').find('input').val('Create Quiz')
    });
    $('.Keyjoin').click(function(e) {
        e.preventDefault();
        $('.cart-row').html('');
    });

    $('#HardQuestion,#NormalQuestion,#EasyQuestion').blur(function(e) {
        e.preventDefault();
        Hard = $('#HardQuestion').val();
        Normal = $('#NormalQuestion').val();
        Easy = $('#EasyQuestion').val();
        if (Hard < 0 || Normal < 0 || Easy < 0) {
            alert('số câu khó / số câu Trung bình / Số Câu dễ phải là số Nguyên DƯƠNG ! OK ?')
            $(this).val(0)
            Hard = $('#HardQuestion').val();
            Normal = $('#NormalQuestion').val();
            Easy = $('#EasyQuestion').val();
            Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
            $('#TotalQuestion').val(Total);
        } else if (Hard % 1 != 0 || Normal % 1 != 0 || Easy % 1 != 0) {
            alert('số câu khó / số câu Trung bình / Số Câu dễ phải là Số Nguyên Dương ! OK ?')
            $(this).val(0)
            Hard = $('#HardQuestion').val();
            Normal = $('#NormalQuestion').val();
            Easy = $('#EasyQuestion').val();
            Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
            $('#TotalQuestion').val(Total);
        } else {
            Total = parseInt(Hard) + parseInt(Normal) + parseInt(Easy);
            $('#TotalQuestion').val(Total);
        }
    });
    $('#NumberOfRemake').blur(function(e) {
        var Remake = $('#NumberOfRemake').val();
        if (Remake < 0) {
            alert('Thấy Ai REMAKE âm chưa :)) người âm phủ à,Số NGUYÊN DƯƠNG PLS')
            $('#NumberOfRemake').val(0);
        } else if (Remake % 1 != 0) {
            alert('REMAKE 1 phần bài ? realy ? :)) Ở đây chúng tôi không làm thế , Số NGUYÊN DƯƠNG PLS')
            $('#NumberOfRemake').val(0);
        }
    });
    $('#SubmitAndCheck').click(function(e) {
        e.preventDefault();
        $('#WrongNameQuiz span').remove();
        $('#WrongInputBank span').remove();
        $('#WrongRandomThi span').remove();
        $('#WrongSday span').remove();
        $('#WrongEday span').remove();
        $('#Wrongkey span').remove();
        $('#WrongaddTime span').remove();

        if ($('#NameQuiz').val().length == 0) {
            $('#WrongNameQuiz').html('<span>Enter Name Quiz</span>');
        }
        if ($(".InputBank")[0].selectedIndex == 0) {
            $('#WrongInputBank').html('<span>Chọn Bank Pls</span>');
        }
        if ($(".RandomThi")[0].selectedIndex == 0) {
            $('#WrongRandomThi').html('<span>Chọn Loại random PLS</span>');
        }
        if ($(".Sday").val().length == 0) {
            $('#WrongSday').html('<span>Chọn Ngày Bắt Đầu PLS</span>');
        }
        if ($(".Eday").val().length == 0) {
            $('#WrongEday').html('<span>Chọn Ngày Kết thúc PLS</span>');
        }
        if ($(".addKey").val().length == 0) {
            $('#Wrongkey').html('<span>Điền Key dùm cái PLS</span>');
        }
        if ($(".addTime").val().length == 0) {
            $('#WrongaddTime').html('<span>Điền Thời Gian Thi PLS</span>');
        }
    });
    $('.Sday,.Eday').blur(function(e) {
        var stringSday = $(".Sday").val()
        var Sdayday = stringSday.slice(8, 10);
        var SdayMonth = stringSday.slice(5, 7);
        var SdayYear = stringSday.slice(0, 4);
        var TotalSday = Sdayday + SdayMonth + SdayYear

        var stringEday = $(".Eday").val()
        var Edayday = stringEday.slice(8, 10);
        var EdayMonth = stringEday.slice(5, 7);
        var EdayYear = stringEday.slice(0, 4);
        var TotalEday = Edayday + EdayMonth + EdayYear
        if (parseInt(TotalSday) > parseInt(TotalEday)) {
            alert("Kết thúc cuộc đời trước khi bắt đầu ?? Ngày Bắt Đầu Trước Ngày Kết thúc ! OK ?")
            $(".Sday").val('')
            $(".Eday").val('')
        }
    });
});


var counter = null;
var counter_stop = null;

$('.addTime').blur(function(e) {
    e.preventDefault();
    $('#countdown').html('');
    var valTime = $('.addTime').val()
    var value = parseInt(valTime);
    var min = 0;
    var hour = 0;
    if (value <= 60 && value >= 1) {
        min = value;
        hour = 1;
    } else if (value > 60) {
        hour = (value / 60);
        min = 60;
    }
    $(function() {
        var ts = new Date(2020, 0, 1),
            newYear = true;

        if ((new Date()) > ts) {
            // The new year is here! Count towards something else.
            // Notice the *1000 at the end - time must be in milliseconds
            ts = (new Date()).getTime() + hour * min * 60 * 1000; //10*24*60*60*1000;
            newYear = false;
        }

        counter_stop = $('#countdown_stop').countdown({
            timestamp: ts,
            callback: function(days, hours, minutes, seconds) {},
            stopeed: true
        });

        counter = $('#countdown').countdown({
            timestamp: ts,
            callback: function(days, hours, minutes, seconds) {}

        });
    });
});

$('.check-outBtn').click(function(e) {
    e.preventDefault();
    $('.quantity-box').find('input').val();
    $('.InputName').val();
    $('.InputBank').val();
});

function validateform() {
    var key = document.myform.key.value;

    if (key == null) {
        alert("Name can't be blank");
        return false;
    } else if (key.length > 10 || key.length <= 1) {
        alert("Key phải từ 1 - 10 kí tự.");
        return false;
    }
}