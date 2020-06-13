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
jQuery(function(){
	getDataAnimalsList();		
	setInterval(getDataAnimalsList(), 10000);
});