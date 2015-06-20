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

        // details modal
        self.details = function (movieId) {
            var detailsModal = $modal.open({
                templateUrl: 'ModalDetails.html',
                controller: 'ModalDetailsController as modal',
                resolve: {
                    movieId: function () { return movieId; }
                }
            });

        };


        // create new movie modal
        self.addNew = function () {
            var createModal = $modal.open({
                templateUrl: 'ModalCreate.html',
                controller: 'ModalCreateController as modal',
                scope: $scope
            });

            createModal.result.then(function () {
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

    angular.module('MovieApp').controller('ModalCreateController', function ($modalInstance, $http) {
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


    angular.module('MovieApp').controller('ModalDetailsController', function (movieId, $modalInstance, $http) {
        var self = this;

        $http.get('/api/movies/' + movieId).success(function(movie) {
            self.movie = movie;
        });

        self.ok = function () {
            $modalInstance.close();
        };

    });




})()