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
				echo "<form method='POST' action='anim_card.php'><div class = 'col animal col-3-lg border'>";
				    	echo "<input type='hidden' name='id_animal' value='$row[0]'>";

				    	echo "<div class = 'row justify-content-center'><div class = 'col'><img class='anim-photo'  src = 'dog_006.png'></div></div>";
				    	echo "<p>Кличка: $row[1]</p>";
				    	echo "<p>Описание: $row[2]</p>";
				    	echo "<input type='submit' value='Просмотр' class='btn btn-success mx-auto'>";
			    echo "</div></form>";
			}
		}
		else{
			echo "<h3>Пока никого нет...</h3>";
		}
		
	}
pg_free_result($result);
pg_close($link);
?>