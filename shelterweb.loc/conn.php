<?php 
$link = pg_connect("port=5432 host=45.141.100.74 dbname=main user=main password=1234") or die ("Произошла ошибка, ". pg_result_error($link));
?>