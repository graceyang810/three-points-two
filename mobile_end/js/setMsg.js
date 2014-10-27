// JavaScript Document
function addphoto(){
	$("#addPhoto").css("background-color","#999");	
	}
function addaudio(){
	$("#addAudio").css("background-color","#999");	
	}
function addvideo(){
	$("#addVideo").css("background-color","#999");	
	}
function qCustomShow(){
	var checkValue=$("#questionList").val();
	if(checkValue == "custom"){
		$("#qCustom_parent").css("display","block");
		}
	else{
		$("#qCustom_parent").css("display","none");
		}
	}
