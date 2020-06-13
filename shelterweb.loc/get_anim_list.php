<?php
require_once("conn.php");

$query = 'SELECT * FROM "Animals"';

$result = pg_query($link, $query) or die("Ошибка $.result, ". pg_last_error($link));
	if($result)
	{
		$rows = pg_num_rows($result);
		if($rows > 0){
			for ($i = 0 ; $i < $rows ; ++$i)
		    {
		    	$row = pg_fetch_row($result);
				echo "<form method='POST' action='animal_card.php'><div class = 'col animal col-3-lg'>";
				    	echo "<input type='hidden' value='$row[0]'>";
				    	echo "<img class='anim-photo' src = '$row[5]'>";
				    	echo "<p>Кличка: $row[1]</p>";
				    	echo "<p>Описание: $row[2]</p>";
				    	echo "<input type='submit' value='Просмотр' class='btn btn-success'>";
			    echo "</div>";
			}
		}
		else{
			echo "<h3>Пока никого нет...</h3>";
		}
		
	}
pg_free_result($result);
pg_close($link);
?>