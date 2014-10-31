// JavaScript Document

function showQRCode(){
	$('#qrcode').on('click', function(){
    layer.tips('<img src="../src/Title.png"></img>', this, {
		time: 5,
        guide: 1,
        style: ['background-color:#D1F5D7; color:#fff', '#F26C4F'],
        maxWidth:120
    });
});
	}
function tPicker_s(){
	WdatePicker({
		dateFmt:'yyyy-MM-dd HH:mm:ss',
		minDate:'2014-09-30 11:30:00'
		});
	}
function tPicker_e(){
	WdatePicker({
		dateFmt:'yyyy-MM-dd HH:mm:ss',
		maxDate:'%y-%M-%d %H:%m:%s'
		});
	}
var idList = {};//复选框选中的id列表
function getCheckedBoxes(){
	$("input[name='checkBox']").each(function(){
		if($(this).prop("checked")){
			idList.push(this.id);
			}
    });
	return idList;
	}
function checkAllBoxes(){
	if($("#checkBoxAll").prop("checked")){
		$("input[name='checkBox']").each(function() {
            $(this).prop("checked",true);
        });
	}else{
		$("input[name='checkBox']").each(function() {
            $(this).prop("checked",false);
        });
	}
}
function userUsed_filter(){
	
	if($("#user_used").prop("checked")){
		$("#username_specify_show").css('display','inline');
		$("#username_specify").css('display','inline');
		$("#modify_Time").css('display','block');
		$('#filterBox').css('height','280pt');
	}else{
		$("#username_specify_show").css('display','none');
		$("#username_specify").css('display','none');
		$("#modify_Time").css('display','none');
		$('#filterBox').css('height','240pt');
	}
	}

function printPage(){
	$("#print_content").jqprint();
	}

	
window.onload = function ()
{
	var oLay = document.getElementById("overlay");
	var oWin,oBtn,oH2;
	var FilterBox = document.getElementById("filterBox");
	var EditBox = document.getElementById("editBox");
	var DeleteBox = document.getElementById("deleteBox");
	var CreateBox = document.getElementById("createBox");
//	oWin = FilterBox;
//	var oBtn = document.getElementsByTagName("button")[1];
//	var oBtn = document.getElementById("filter");
	var FilterClose = document.getElementsByTagName("span")[0];
	var EditClose = document.getElementsByTagName("span")[1];
	var DeleteClose = document.getElementsByTagName("span")[2];
	var CreateClose = document.getElementsByTagName("span")[3];
	var bDrag = false;
	var FilterBtn = document.getElementById("filter");
	var EditBtn = document.getElementById("edit");
	var DeleteBtn = document.getElementById("delete");
	var CreateBtn = document.getElementById("create");

	FilterBtn.onclick = function(){
		oWin = FilterBox;
		oBtn = FilterBtn;
		showBox();
		};
	EditBtn.onclick = function(){
		oWin = EditBox;
		oBtn = EditBtn;
		idList = [];
		getCheckedBoxes();
		showBox();
		console.log(idList);
		};
	DeleteBtn.onclick = function(){
		oWin = DeleteBox;
		oBtn = DeleteBtn;
		idList = [];
		getCheckedBoxes();
		showBox();
		console.log(idList);
		};
	CreateBtn.onclick = function(){
		oWin = CreateBox;
		oBtn = CreateBtn;
		showBox();
		};	
	function showBox()
	{
		oLay.style.display = "block";
		oWin.style.display = "block"	
	};
	
	
	FilterClose.onclick = function ()
	{
		oLay.style.display = "none";
		oWin.style.display = "none"
		
	};
	EditClose.onclick = function ()
	{
		oLay.style.display = "none";
		oWin.style.display = "none"
		
	};
	DeleteClose.onclick = function ()
	{
		oLay.style.display = "none";
		oWin.style.display = "none"
		
	};
	CreateClose.onclick = function ()
	{
		oLay.style.display = "none";
		oWin.style.display = "none"
		
	};

};