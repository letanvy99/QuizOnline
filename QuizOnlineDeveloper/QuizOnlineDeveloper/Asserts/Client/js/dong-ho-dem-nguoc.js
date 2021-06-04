// load từ DB lên được số (s) của bài quiz
var secQuiz = 20;
var minQuiz = secQuiz / 60;
// Thiết lập thời gian đích mà ta sẽ đếm
var countDownDate = new Date(new Date().getTime() + (minQuiz * 60 * 1000 + 2000));

// cập nhập thời gian sau mỗi 1 giây
var x = setInterval(function () {

    // Lấy thời gian hiện tại
    var now = new Date().getTime();

    // Lấy số thời gian chênh lệch
    var distance = countDownDate - now;
    console.log('time' + distance);
    // Tính toán số ngày, giờ, phút, giây từ thời gian chênh lệch
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    hours = hours < 10 ? "0" + hours : hours;
    minutes = minutes < 10 ? "0" + minutes : minutes;
    seconds = seconds < 10 ? "0" + seconds : seconds;

    if (distance >= 300000) {
        // HIển thị chuỗi thời gian trong thẻ p
        document.getElementById("donghodemnguoc").innerHTML =
            '<span class ="divHrs">' + hours + '</span>' + "<span class='dau2cham'>:</span>"
            + '<span class ="divHrs">' + minutes + '</span>' + "<span class='dau2cham'>:</span>" + '<span class ="divHrs">' + seconds + '</span>';
    }
    if (distance < 300000) {
        document.getElementById("donghodemnguoc").innerHTML =
            '<span class ="divHrsBelow5Mins">' + hours + '</span>' + "<span class='dau2cham'>:</span>"
            + '<span class ="divHrsBelow5Mins">' + minutes + '</span>' + "<span class='dau2cham'>:</span>" + '<span class ="divHrsBelow5Mins">' + seconds + '</span>';
    }
    // Nếu thời gian kết thúc, hiển thị chuỗi thông báo
    if (distance < 0) {
        clearInterval(x);
        document.getElementById("donghodemnguoc").innerHTML = "<span class='text-danger'>Hết giờ làm bài thi!</span>";
        $('#modal-timeout').modal();
    }
}, 1000);
        // ClassName=“alert alert-danger &&{isActive} active”