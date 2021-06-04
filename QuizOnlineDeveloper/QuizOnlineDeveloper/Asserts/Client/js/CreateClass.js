
$(document).ready(function(){
    $("#btn-them").click(function(){        
        var username = $("#add").val();     
            if(username!="")
            $(".areastudent").append( username+"<br>");
      });
    });