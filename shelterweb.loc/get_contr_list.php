<?php
require_once("conn.php");

$query = 'SELECT con.*, sh."Name" AS shelterName FROM "Contracts" AS con INNER JOIN "Shelters" AS sh ON con."PerformerShelterId" = sh."Id"';

$result = pg_query($link, $query) or die("Ошибка $.result, ". pg_last_error($link));
	if($result)
	{
		$rows = pg_num_rows($result);
		if($rows > 0){
			for ($i = 0 ; $i < $rows ; ++$i)
		    {
		    	$row = pg_fetch_row($result);
				echo "<div class = 'col col-7-lg  animal border'>";
				    	echo "<input type='hidden' name='id_animal' value='$row[0]'>";
				    	echo "<p>Контракт №$row[0]</p>";
				    	echo "<p>Адрес: $row[1]</p>";
				    	echo "<p>Задание: $row[2]</p>";
				    	echo "<p>Исполнитель: $row[4]</p>";
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