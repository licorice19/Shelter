<?php
session_start();
if(isset($_SESSION['login']))
{
	header("location: /index.php");
}
else
{
   	require_once('conn.php');

            $login_users = pg_escape_string($link, trim($_POST['login']));
            $pass_users = pg_escape_string($link, trim($_POST['password']));
            if(isset($_POST['submit'])) {
	            if(!empty($login_users) && !empty($pass_users)) {

	                $query = "SELECT * FROM \"AuthData\" WHERE \"Login\" = '$login_users' AND \"Password\" = '$pass_users'";

	                $result = pg_query($link, $query);

	                if(pg_num_rows($result) == 1) {

	                    $row = pg_fetch_row($result);
	                    $_SESSION['id_auth'] = $row[0];
	                    $_SESSION['role'] = $row[3];
	                    header('Location: index.php');
	                	}
	                	else{
	                		echo "<div class='alert alert-warning' role='alert'>Ошибка: неверный логин или пароль</div>";
				            }
			            }
		            else{
		            	echo "<div class='alert alert-warning' role='alert'>Ошибка: пустые поля ввода</div>";
		            }
		            pg_free_result($result);
			}   
			
			pg_close($link);
} 	
?>
<!DOCTYPE html>
<html>
<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="main.css">
    <title>Сервис по отлову бездомных животных</title>
  </head>
  <body>
    <div class = "head">
	    <nav class="navbar navbar-expand-lg navbar-dark">
    <a class="navbar-brand" href="index.php" ><img width='100px' src='logo.png'></a>
	    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
	      <span class="navbar-toggler-icon"></span>
	    </button>

	  <div class="collapse navbar-collapse" id="navbarSupportedContent">
	    <ul class="navbar-nav mr-auto">
	      <li class="nav-item">
	        <a class="nav-link" href="index.php">Главная</a>
	      </li>
	       <li class="nav-item">
       		 <a class="nav-link" href="#">Пожертвовать приюту<span class="sr-only">(current)</span></a>
      	</li>
      <li class="nav-item">
        <a class="nav-link" href="question.php">Подать жалобу<span class="sr-only">(current)</span></a>
      </li>
	        <a class="nav-link" href="#">Авторизация<span class="sr-only">(current)</span></a>
	      </li>

      </li>
	    </ul>
	  </div>
	</nav>
    </div>
    <div class="container-fluid">
		<div class="row">
			<div class="col">
			</div>
			<div class="col-3-md col-6-sm">
				<form class="signin-form" method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">
					<fieldset>
						<legend><b>Вход</b></legend>
						<label for='login'>Логин</label>
						<input type="text" name="login">
						<label for='password'>Пароль</label>
						<input type="password" name="password">
						<input type="submit" name="submit" value="Войти" class="btn btn-outline-success">
					</fieldset>
				</form>
			</div>
			<div class="col">
			</div>
		</div>
	</div>
    
      
  
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <script type="text/javascript" src = "actions.js"></script>

  </body>
</html>