// JavaScript Document

function showQRCode(){
	$('#qrcode').on('click', function(){
    layer.tips('哈罗美丽的虫子！！这里放画二维码的代码~<img src="../src/Title.png"></img>', this, {
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
		showBox();
		};
	DeleteBtn.onclick = function(){
		oWin = DeleteBox;
		oBtn = DeleteBtn;
		showBox();
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