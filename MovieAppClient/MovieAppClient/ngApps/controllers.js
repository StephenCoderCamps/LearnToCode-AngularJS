(function () {


    angular.module('MovieApp').controller('MovieListController', function ($http, $modal, $scope) {
        var self = this;

        // defaults
        self.currentPageIndex = 1;

        $http.get('/api/categories').success(function (results) {
            self.selectedCategory = results[0];
            self.categories = results;
            fetchMovies();
        });

        self.selectCategory = function () {
            self.currentPageIndex = 1;
            fetchMovies();
        };


        self.pageChanged = function () {
            fetchMovies();
        };

        // modal
        self.addNew = function () {
            var modalInstance = $modal.open({
                templateUrl: 'myModalContent.html',
                controller: 'ModalController as modal',
                scope: $scope
            });

            modalInstance.result.then(function () {
                fetchMovies();
            });
        };



        function fetchMovies() {
            $http.get('/api/movies/?categoryId=' + self.selectedCategory.Id + '&pageIndex=' + (self.currentPageIndex-1))
                .success(function (results) {
                    self.movies = results.Movies;
                    self.moviesTotalCount = results.TotalCount;
                });
        }


    });

    angular.module('MovieApp').controller('ModalController', function ($modalInstance, $http) {
        var self = this;

        self.save = function () {
            $http.post('/api/movies', self.newMovie).success(function () {
                $modalInstance.close();
            });
        };

        self.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

    });

})()