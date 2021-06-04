$("#thongtinchung").css("font-weight"," bold");
$(".oldpass, .newpass, .renewpass").hide();
$(".email").prop('disabled', true);
$("#changeinfo").hide();
$(document).ready(function(){
    //kick vào nút update --> ẩn màn hình update, hiển thị lên màn hình chỉnh sửa và làm thao tác update
    $("#update").click(function(){
        $("#changeinfo").hide();
        $("#info").show(); 
        var username =   $(".username").val();            
        var fullname =   $(".fullname").val();            
        var department =   $(".department").val();            
        var phone =   $(".phone").val();            
        var address =   $(".address").val();
        
        $("#username").text(username);
        $("#fullname").text(fullname);
        $("#department").text(department);
        $("#phone").text(phone);
        $("#address").text(address);

        $("#changeinfo,.oldpass, .newpass, .renewpass").hide();
        $("#info, .fullname_input,.username_input,.pass_input,#changepass,.department_input,.phone_input,.address_input").show();
        $("#thongtinchung").css("font-weight"," bold");
        $("#changeusername").css("font-weight"," normal");
        $("#changepassword").css("font-weight"," normal");
      });
      $("#changepass").click(function(){        
        $(".oldpass, .newpass, .renewpass").toggle(200);    
      });
    //kick vào nút chỉnh sửa --> ẩn màn hình chỉnh sửa, hiển thị lên màn hình update
    $("#change").click(function(){
        $("#info").hide();
        $("#changeinfo").show();

        var usernameinfo= $("#username").text();
        var fullnameinfo= $("#fullname").text();
        var departmentinfo= $("#department").text();
        var phoneinfo= $("#phone").text();
        var addressinfo= $("#address").text();

        $(".username").val(usernameinfo);
        $(".fullname").val(fullnameinfo);
        $(".department").val(departmentinfo);
        $(".phone").val(phoneinfo);
        $(".address").val(addressinfo);
    });

    $("#thongtinchung").click(function(){
        $("#changeinfo,.oldpass, .newpass, .renewpass").hide();
        $("#info, .fullname_input,.username_input,.pass_input,#changepass,.department_input,.phone_input,.address_input").show();

        $("#thongtinchung").css("font-weight"," bold");
        $("#changeusername").css("font-weight"," normal");
        $("#changepassword").css("font-weight"," normal");
        
    });
    $("#changeusername").click(function(){
        $("#changeinfo,.username_input").show();
        $("#info, .fullname_input,.pass_input,.department_input,.phone_input,.address_input").hide();

        $("#thongtinchung").css("font-weight"," normal");
        $("#changeusername").css("font-weight"," bold");
        $("#changepassword").css("font-weight"," normal") ;
    });
    $("#changepassword").click(function(){
        $("#changeinfo,.pass_input,.oldpass, .newpass, .renewpass").show();
        $("#info,#changepass, .fullname_input,.username_input,.department_input,.phone_input,.address_input").hide(); 

        $("#thongtinchung").css("font-weight"," normal");
        $("#changeusername").css("font-weight"," normal");
        $("#changepassword").css("font-weight"," bold"); 
    });
    });

  