var i = 0;
function Editor(index) {
    ClassicEditor
        .create(document.querySelector('#editor' + (index) + ''))
        .then(editor => {
            console.log(editor);
        })
        .catch(error => {
            console.error(error);
        });
}
$(document).ready(function () {
    //back to top
    mybutton = document.getElementById("myBtn");

    // When the user scrolls down 20px from the top of the document, show the button
    window.onscroll = function () { scrollFunction() };

    function scrollFunction() {
        if (document.body.scrollTop > 300 || document.documentElement.scrollTop > 300) {
            mybutton.style.display = "block";
        } else {
            mybutton.style.display = "none";
        }
    }

    // When the user clicks on the button, scroll to the top of the document
    function topFunction() {
        document.body.scrollTop = 0; // For Safari
        document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
    }


    //
    $('#stateChoose1').on('change', function (e) {

        var checkindex = $("#stateChoose1")[0].selectedIndex;
        // if (checkindex == 1) {
        //     $('#add').append('<div class="col-lg-12 card-quiz"><div class="DeleteQuestion"><span><i class="fa fa-trash"></i></span></div><div class="form-group "><div class="row"><div class="col-lg-5 "><h1>Type Question : Normal</h1></div></div></div> <hr><div id="formInfo"></div><div class="form-group defaultcard1"> <div class="col-lg-12 text-editor"><div id="editor' + (++i) + '">This is some sample content for ckeditor.</div></div> <div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="NormalCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="NormalCheck" id="CheckRight" value="checkedValue"></small></div><div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="NormalCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="NormalCheck" id="CheckRight" value="checkedValue"></small></div></div></div>')
        //     Editor(i);
        // }
        if (checkindex == 1) {
            $('#add').append(' <div class="col-lg-12 card-quiz"> <div class="row"> <div class="col-lg-10 "> <h1>Type Question : Normal</h1> </div> <div class="col-lg-1 DeleteQuestion"><span><i class="fa fa-trash fa-3x "></i></span></div> </div> <hr> <div id="formInfo"></div> <div class="form-group defaultcard1"> <div class="col-lg-12 text-editor"> <div id="editor' + (++i) + '">This is some sample content for ckeditor. </div> </div> <div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox" name="NormalCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox" name="NormalCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox" name="NormalCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox" name="NormalCheck" id="CheckRight" value="checkedValue"></small></div> </div> </div>')
            Editor(i);
        }
        // if (checkindex == 2) {
        //     $('#add').append('<div class="col-lg-12 card-quiz"><h1 class="DeleteQuestion"><span><i class="fa fa-trash "></i></span></h1><div class="form-group "><div class="row"><div class="col-lg-4 "><h1>Type Question : Multi</h1></div></div></div> <hr><div id="formInfo"></div><div class="form-group defaultcard2"> <div class="col-lg-12 "><input type="text" class="form-control" name="" id="" placeholder="Question ?"></div> <div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="MultiCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="MultiCheck" id="CheckRight" value="checkedValue"></small></div><div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="MultiCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="MultiCheck" id="CheckRight" value="checkedValue"></small></div></div><div class="col-lg-12 addAnswer"><button type="submit" class="btn"><h1>+ Thêm Answer</h1></button></div></div>')
        // }
        if (checkindex == 2) {
            $('#add').append('<div class="col-lg-12 card-quiz"><h1 class="DeleteQuestion"><span><i class="fa fa-trash "></i></span></h1><div class="form-group "><div class="row"><div class="col-lg-5 "><h1>Type Question :Media</h1></div><div class="col-lg-4 typeQuestion"> </div> <div class="col-lg-4"><input type="file" name="filename"></div></div></div> <hr><div id="formInfo"></div><div class="form-group defaultcard3"> <div class="col-lg-12 "><input type="text" class="form-control" name="Question" id="" placeholder="Question ?"></div> <div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="AudioCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="AudioCheck" id="CheckRight" value="checkedValue"></small></div><div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="AudioCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="AudioCheck" id="CheckRight" value="checkedValue"></small></div></div></div>')
        }
        if (checkindex == 3) {
            $('#add').append('<div class="col-lg-12 card-quiz"><h1 class="DeleteQuestion"><span><i class="fa fa-trash "></i></span></h1><div class="form-group "><div class="row"><div class="col-lg-5 "><h1>Type Question :IMG</h1></div><div class="col-lg-4 typeQuestion"> </div> <div class="col-lg-3"><input type="file" name="filename"></div></div></div> <hr><div id="formInfo"></div><div class="form-group defaultcard4"> <div class="col-lg-12 "><input type="text" class="form-control" name="Question" id="" placeholder="Question ?"></div> <div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="ImgCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="ImgCheck" id="CheckRight" value="checkedValue"></small></div><div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="ImgCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="ImgCheck" id="CheckRight" value="checkedValue"></small></div></div></div>')
        }
        $('.DeleteQuestion').click(function (e) {
            // e.preventDefault();
            $(this).parent().parent().remove('.card-quiz');
        });
        $('.addAnswer').off('click').click(function (e) {
            e.preventDefault();
            $(this).parent().append('<div class="col-lg-6 card-NewAnswer"> <input type="text" class="form-control" name="" id="" placeholder="A.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="MultiCheck" id="CheckRight" value="checkedValue"></small> <i class="fa fa-trash DeleteAnswer">Delete</i></div>');
            $('.DeleteAnswer').click(function (e) {
                e.preventDefault();
                $(this).parent().remove('.card-NewAnswer');
            });
        });
        $("#stateChoose1")[0].selectedIndex = 0;
        // CKEditor

    });

    $('#stateChoose2').on('change', function (e) {

        var checkindex = $("#stateChoose2")[0].selectedIndex;
        if (checkindex == 1) {
            $('#add').append('<div class="col-lg-12 card-quiz"><h1 class="DeleteQuestion"><span><i class="fa fa-trash "></i></span></h1><div class="form-group "><div class="row"><div class="col-lg-5 "><h1>Type Question : Normal</h1></div></div></div> <hr><div id="formInfo"></div><div class="form-group defaultcard1"> <div class="col-lg-12 "><input type="text" class="form-control" name="Question" id="" placeholder="Question ?"></div> <div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="NormalCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="NormalCheck" id="CheckRight" value="checkedValue"></small></div><div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="NormalCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="NormalCheck" id="CheckRight" value="checkedValue"></small></div></div></div>')
        }
        // if (checkindex == 2) {
        //     $('#add').append('<div class="col-lg-12 card-quiz"><h1 class="DeleteQuestion"><span><i class="fa fa-trash "></i></span></h1><div class="form-group "><div class="row"><div class="col-lg-4 "><h1>Type Question : Multi</h1></div></div></div> <hr><div id="formInfo"></div><div class="form-group defaultcard2"> <div class="col-lg-12 "><input type="text" class="form-control" name="" id="" placeholder="Question ?"></div> <div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="MultiCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="MultiCheck" id="CheckRight" value="checkedValue"></small></div><div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="MultiCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="MultiCheck" id="CheckRight" value="checkedValue"></small></div></div><div class="col-lg-12 addAnswer"><button type="submit" class="btn"><h1>+ Thêm Answer</h1></button></div></div>')
        // }
        if (checkindex == 2) {
            $('#add').append('<div class="col-lg-12 card-quiz"><h1 class="DeleteQuestion"><span><i class="fa fa-trash "></i></span></h1><div class="form-group "><div class="row"><div class="col-lg-5 "><h1>Type Question :Media</h1></div><div class="col-lg-4 typeQuestion"> </div> <div class="col-lg-4"><input type="file" name="filename"></div></div></div> <hr><div id="formInfo"></div><div class="form-group defaultcard3"> <div class="col-lg-12 "><input type="text" class="form-control" name="Question" id="" placeholder="Question ?"></div> <div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="AudioCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="AudioCheck" id="CheckRight" value="checkedValue"></small></div><div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="AudioCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="AudioCheck" id="CheckRight" value="checkedValue"></small></div></div></div>')
        }
        if (checkindex == 3) {
            $('#add').append('<div class="col-lg-12 card-quiz"><h1 class="DeleteQuestion"><span><i class="fa fa-trash "></i></span></h1><div class="form-group "><div class="row"><div class="col-lg-5 "><h1>Type Question :IMG</h1></div><div class="col-lg-4 typeQuestion"> </div> <div class="col-lg-3"><input type="file" name="filename"></div></div></div> <hr><div id="formInfo"></div><div class="form-group defaultcard4"> <div class="col-lg-12 "><input type="text" class="form-control" name="Question" id="" placeholder="Question ?"></div> <div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="ImgCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="ImgCheck" id="CheckRight" value="checkedValue"></small></div><div class="col-lg-6 "><input type="text" class="form-control" name="" id="" placeholder="A.Something"> <small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="ImgCheck" id="CheckRight" value="checkedValue"></small></div> <div class="col-lg-6"><input type="text" class="form-control" name="" id="" placeholder="B.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="ImgCheck" id="CheckRight" value="checkedValue"></small></div></div></div>')
        }
        $('.DeleteQuestion').click(function (e) {
            e.preventDefault();
            $(this).parent().remove('.card-quiz');
        });
        $('.addAnswer').off('click').click(function (e) {
            e.preventDefault();
            $(this).parent().append('<div class="col-lg-6 card-NewAnswer"> <input type="text" class="form-control" name="" id="" placeholder="A.Something"><small id="helpId" class="form-text text-muted">Quiz Answer Right ? Check Here<input type="checkbox"name="MultiCheck" id="CheckRight" value="checkedValue"></small> <i class="fa fa-trash DeleteAnswer">Delete</i></div>');
            $('.DeleteAnswer').click(function (e) {
                e.preventDefault();
                $(this).parent().remove('.card-NewAnswer');
            });
        });
        $("#stateChoose2")[0].selectedIndex = 0;
    });

    $('.AddQuestionMove').hide();

    $(window).scroll(function (event) {
        var pos_body = $('html,body').scrollTop();
        // console.log(pos_body);
        if (pos_body > 370) {
            $('.AddQuestion').hide('300');
            $('.AddQuestionMove').show('300');
        } else {
            $('.AddQuestion').show('300');
            $('.AddQuestionMove').hide('50');
        }

    });
    $('.back-to-top').click(function (event) {
        $('html,body').animate({ scrollTop: 0 }, 1400);
    });


})