<html> 
    <head>
        <title>StarSync</title>
        <link rel="stylesheet" type="text/css" href="/css/bootstrap-dark.min.css">
        <link rel="stylesheet" type="text/css" href="/css/loginPage.css">
        <link href="https://fonts.googleapis.com/css2?family=Baloo+Thambi+2:wght@400;500;600;700;800&display=swap" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    </head>
    <body>
        <div class="container">
            <div class="login-box">
            <div class="row">
                <div class="col-lg headerBox">
                    <h1 class="text-center lHeader">StarSync</h1>
                </div>
            </div>
            <div class="row">
                <div class = "col-md-6 login-left">
                    <h2> Login Here </h2>
                    <form action="validate.php" method="POST">
                        <div class="form-group">
                            <label>Username</label>
                            <input type="text" name="user" class="form-control" required>
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <input type="password" name="pass" class="form-control" required>
                        </div>
                        <button type="submit" class="ulButtons"> Login </button>
                    </form>
                </div>

                <div class = "col-md-6 login-right">
                    <h2> Register Here </h2>
                    <form action="register.php" method="POST">
                        <div class="form-group">
                            <label>Username</label>
                            <input type="text" name="user" class="form-control" required>
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <input type="password" name="pass" class="form-control" required>
                        </div>
                        <button type="submit" class="ulButtons"> Register </button>
                    </form>
                </div>
            </div>
        </div>
    </body>
</html>