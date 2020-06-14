<?php
session_start();
?>

<!DOCTYPE html>
<html lang="ru">
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
      <li class="nav-item active">
        <a class="nav-link" href="#">Главная<span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Пожертвовать приюту<span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="question.php">Подать жалобу<span class="sr-only">(current)</span></a>
      </li>
      <?php if(isset($_SESSION['role'])){ 
        if($_SESSION['role'] = '2' || $_SESSION['role'] = '3' || $_SESSION['role'] = '4'){  ?>
        <li class="nav-item">
          <a class="nav-link" href="contracts.php">Контракты</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="zayav.php">Заявки</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="exit.php">Выйти</a>
        </li>
        <?php }elseif($_SESSION['role'] = '1' ) {  ?>
        <li class="nav-item">
          <a class="nav-link" href="auth.php">Стать хозяинов</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="exit.php">Выйти</a>
        </li>
      <?php }}else{ ?>
        <li class="nav-item">
        <a class="nav-link" href="auth.php">Авторизация</a>
      </li>
    <?php } ?>
    </ul>
  </div>
</nav>
    </div>
    <div class="container-fluid">
      <div class= "row body">
        <div class="col">
          <div class="row info">
                        <div class="col">
                          <div class="row">
                            <div class="col interface border">
                              <p class="info">Животные в приютах</p>
                            </div>

                          </div>
                          <div class="row anim-list">
                  
                          </div>
                        </div>
          </div>
        </div>
      </div>
      <div class="footer">
        
      </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <script type="text/javascript" src = "actions.js"></script>

  </body>
</html>