angular.module('BookApp', [])
    .controller('BookCtrl', function ($scope, $http)
    {
        $scope.bookId = 1;
        var ResetVariables = function () {
            $scope.title = "loading...";
            $scope.subTitle = "";
            $scope.edition = "";
            $scope.extraInfo = "";
            $scope.brandImage = "";
            $scope.subInfo = "";
            $scope.keyPoints = [];
            $scope.authors = "";
            $scope.highlightInfo = "";
            $scope.specialOfferInfo = "";
            $scope.hasExtraInfo = false; //Control "Edition" display position
        }

        $scope.book = function ()
        {
            ResetVariables();

            if (angular.isNumber($scope.bookId))
            {
                $http.get("/api/books/" + $scope.bookId).success(function (data, status, headers, config) {
                    $scope.title = data.title;
                    $scope.subTitle = data.subTitle;
                    $scope.edition = data.edition;
                    $scope.extraInfo = data.extraInfo;
                    $scope.brandImage = data.brandImage;
                    $scope.subInfo = data.subInfo;
                    $scope.keyPoints = data.keyPoints;
                    $scope.highlightInfo = data.highlightInfo;
                    $scope.specialOfferInfo = data.specialOfferInfo;
                 
                    //Add "And" between authors
                    if (data.authors)
                    {
                        var lastAuthorIndex = data.authors.length - 1;
                        for (var i = 0; i < lastAuthorIndex; i++)
                        {
                            $scope.authors = data.authors[i].fullName + ", " + data.authors[i].title + " and ";
                        }
                        $scope.authors = $scope.authors + data.authors[lastAuthorIndex].fullName + ", " + data.authors[lastAuthorIndex].title;
                    }

                    if($scope.extraInfo)
                    {
                        $scope.hasExtraInfo = true;
                    }
                }).error(function (data, status, headers, config) {
                    $scope.title = "This book does not exist.";
                });
            }
            else
            {
                $scope.title = "Please pass a number.";
            }
        };
    });