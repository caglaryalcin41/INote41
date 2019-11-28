var apiUrl = "http://localhost:52231/"

var app = angular.module("myApp", ["ngRoute"]);

app.config(function ($routeProvider) {

    $routeProvider.when("/", {
        templateUrl: "Pages/Main.html",
        controller: "MainCtrl"
    }).when("/Login", {
        templateUrl: "Pages/Login.html",
        controller: "LoginCtrl"
    }).when("/Register", {
        templateUrl: "Pages/Register.html",
        controller: "RegisterCtrl"
    });
});

app.controller("MainCtrl", function ($scope) {
    $scope.message = "Anasayfadasınız";
});
app.controller("LoginCtrl", function ($scope) {
    $scope.message = "Giriş";
});
app.controller("RegisterCtrl", function ($scope, $http) {
    $scope.errors = [];
    $scope.successMessage = "";


    $scope.user = {
        Email: "caglaryalcin41@gmail.com",
        Password: "Ankara.1",
        ConfirmPassword: "Ankara.1"
    };

    $scope.register = function (e) {
        $scope.errors = [];
        e.preventDefault();
        $http.post(apiUrl + "api/Account/Register", $scope.user).then(function (response) {
            $scope.user = {
                Email: "",
                Password: "",
                ConfirmPassword: ""
            };
            $scope.successMessage = "Kayıt Oldun :)";
        }, function (response) {
            $scope.errors = getErrors(response.data.ModelState);
    });
    };

    $scope.hasErrors = function () {
        return $scope.errors.length > 0;
    };

});

function getErrors(modelState) {

    var errors = [];

    for (var key in modelState) {
        for (var i = 0; i < modelState[key].length; i++) {
            errors.push(modelState[key][i]);

            if (modelState[key][i].includes("zaten alınmış.")) {
                break;
            }
        }
    }

    return errors;
}