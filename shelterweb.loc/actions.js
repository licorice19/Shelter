function getDataAnimalsList(){
		$.ajax({
		url:"get_anim_list.php",
		type: "POST",
		dataType: "html",
		success: function(data){
			$(".anim-list").html(data);
			console.log("1");
		}});
	}
	function getContrList(){
		$.ajax({
		url:"get_contr_list.php",
		type: "POST",
		dataType: "html",
		success: function(data){
			$(".contr-list").html(data);
			console.log("1");
		}});
	}
	function getReqList(){
		$.ajax({
		url:"get_req_list.php",
		type: "POST",
		dataType: "html",
		success: function(data){
			$(".req-list").html(data);
			console.log("1");
		}});
	}
jQuery(function(){
	getDataAnimalsList();
	getContrList();
	getReqList();
	setInterval(getDataAnimalsList(), 10000);
});