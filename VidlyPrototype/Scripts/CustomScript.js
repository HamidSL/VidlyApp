$(document).ready(function () {

    $("#movie-details-modal, .close").on('click', function () {
        $(".movie-trailer-wrapper iframe").attr('src', '');
    });
    var movieColl = {
        'base': "https://image.tmdb.org/t/p/original",
        'id': ""
    };

    var id = "";
    $("#api-movies").on('click', 'a', function (e) {
        e.preventDefault();

        id = $(this).attr('data-movie-id');


        $.ajax({
            url: "https://api.themoviedb.org/3/movie/" + id + "?api_key=7538a1ba766c36605ab0e8e10bab23da&append_to_response=videos",
            method: "GET",
            dataType: "json",
            success: function (data) {

                var trailerKey = [];
                var trailerBase = "https://www.youtube.com/embed/";
                //movie trailer
                data.videos.results.forEach(function (value) {
                    trailerKey.push(value['key']);
                });

                //console.log(trailerKey[0]);
                $(".movie-trailer-wrapper iframe").attr('src', trailerBase + trailerKey[0]);

                $(".poster-space").html("<img src='" + movieColl.base + data.poster_path + "' alt='" + data.title + "-poster' class='img-fluid rounded'>");

                $(".movie-details-space h3").addClass('text-capitalize').text(data.title);
                $(".movie-language").addClass('text-uppercase').text(data.original_language);
                $(".movie-release-date").text(data.release_date);
                $(".movie-rating").text(data.vote_average + " out of " + data.vote_count + " responses");
                $(".movie-runtime").text(" " + data.runtime + "min");
                $(".movie-description").text(data.overview);

                var genre = "";
                data.genres.forEach(function (value) {
                    genre = value['name'];
                });

                $(".movie-genre").text(genre);

                var country = "";
                data.production_countries.forEach(function (value) {
                    country = value['name'];
                });

                $(".movie-country").text(country);

                //acquire actor data
                $.ajax({
                    url: "https://api.themoviedb.org/3/movie/" + id + "/credits?api_key=7538a1ba766c36605ab0e8e10bab23da",
                    method: "GET",
                    dataType: "json",
                    success: function (data) {

                        var actor = {
                            'character': [],
                            'name': []
                        };

                        var actorHolder = "";
                        data.cast.forEach(function (value, key) {

                            actor.character.push(value['character']);
                            actor.name.push(value['name']);
                            if (key < 5)
                                actorHolder += value['name'] + ", ";


                        });

                        $(".movie-stars").html(actorHolder);
                        //console.log(data);
                    },
                    error: function (x) {
                        console.log(x.status);
                    }
                });
            },
            error: function (x) {
                console.log(x.status);
            }
        });
    });

    $.ajax({
        url: "https://newsapi.org/v2/top-headlines?category=technology&country=us&apiKey=e773f762c809423eae750354d71aaeb7",
        method: "GET",
        dataType: "json",
        success: function (data) {
            //console.log(data.articles);
            var articles = {
                'title': [],
                'urls': []

            };

            if (data.status == "ok") {

                data.articles.forEach(function (value, key) {
                    articles.title.push(value['title']);
                    articles.urls.push(value['url']);
                });

                var i = 0;
                setInterval(function () {
                    if (i < articles.title.length) {
                        $(".movie-rss").html("<a href='" + articles.urls[i] + "' target='_blank'>" + articles.title[i] + "</a>");
                        i++;
                    } else {
                        i = 0;
                    }

                }, 5000);


            }
        },
        error: function (x) {
            console.log(x.status);
        }
    });
    var movies = {
        'id': [],
        'originalLanguage': [],
        'originalTitle': [],
        'overview': [],
        'posterPath': [],
        'releaseDate': [],
        'title': [],
        'video': [],
        'voteAverage': [],
        'voteCount': [],
        'popularity': [],
        'base': 'https://image.tmdb.org/t/p/original',
    };

    //Trending movies section
    $.ajax({
        url: "https://api.themoviedb.org/3/trending/movie/day?api_key=7538a1ba766c36605ab0e8e10bab23da&language=en-US&page=1",
        method: "GET",
        dataType: "json",
        success: function (data) {
            data.results.forEach(function (value) {
                movies.id.push(value['id']);
                movies.posterPath.push(value['poster_path']);
                movies.title.push(value['title']);
                movies.video.push(value['video']);
            });

            var movieData = "";

            for (var i = 0; i < 7; i++) {
                movieData += "<div class='card'>";
                movieData += "<img src='" + movies.base + movies.posterPath[i] + "' alt='" + movies.title[i] + "-poster' class='rounded img-fluid'>";
                movieData += "<div class='dark-overlay rounded-top'></div>";
                movieData += "<div class='card-img-overlay'><small class='font-weight-bold text-capitalize'><a href='#' data-target='#movie-details-modal' data-toggle='modal' data-movie-id='" + movies.id[i] + "'>" + movies.title[i] + "</a></small>";
                movieData += "<br><a href='#' data-target='#movie-details-modal' data-toggle='modal' data-movie-id='" + movies.id[i] + "'><i class='fas fa-play-circle mr-1'></i><a href='#' data-target='#movie-details-modal' data-toggle='modal' data-movie-id='" + movies.id[i] + "'<i class='fas fa-info-circle'></i></a></div></div>";

                //add to moviedata tag
                $("#api-movies").html(movieData);


            }

            $("#trending-daily-section a").css({ "text-decoration": "none", "color": "#e2e0e0" })
        },
        error: function (x) {
            console.log(x.status);
            $("#api-movies").addClass('text-center').html("<h4 class='display-5'>There are no movies to display</h4>");
        }
    });

    //Now playing movies section - Slider Section
    $.ajax({
        url: "https://api.themoviedb.org/3/movie/now_playing?api_key=7538a1ba766c36605ab0e8e10bab23da&language=en-US&page=1",
        method: "GET",
        dataType: "json",
        success: function (data) {
            var slideData = {
                'base': "https://image.tmdb.org/t/p/original"
            };
            data.results.forEach(function (value, key) {
                var captionData = "";

                if (key < 4) {

                    //Other properties acquisition starts here
                    $.ajax({
                        url: "https://api.themoviedb.org/3/movie/" + value['id'] + "?api_key=7538a1ba766c36605ab0e8e10bab23da&language=en-US",
                        method: "GET",
                        dataType: "json",
                        success: function (data) {
                            $(".movie-image-" + (key + 1)).css({ "background": "url(" + slideData.base + value['backdrop_path'] + ")", "background-size": "cover", "background-repeat": "no-repeat" });
                            
                            //caption filling
                            captionData = "<h4 class='display-4'>" + value['title'] + "</h4>";
                            captionData += "<p>" + value['overview'] + "<br>";
                            captionData += "<span class='small'>" + "<i class='far fa-comment'></i> " + value['original_language'].toUpperCase();
                            //genres container

                            var genresContainer = "";
                            console.log(data.genres);

                            data.genres.forEach(function (value, key) {
                                if (key != data.genres.length - 1)
                                    genresContainer += value['name'] + ", ";
                            });

                            captionData += "<i class='fas fa-theater-masks'></i> " + genresContainer;

                            captionData += "<i class='far fa-calendar-alt'></i> " + value['release_date'];
                            captionData += "<i class='far fa-clock'></i> " + data.runtime + "min";
                            captionData += "<i class='far fa-star'></i> " + value['vote_average'] + " out of " + value['vote_count'] + " responses";
                            captionData += "<a class='border-left border-2 ml-2 pl-2' href='https://www.themoviedb.org/' target='_blank'><img src='Content/Images/tmdb_logo.png' alt='tmdb_logo' height='30'></span</span></p>"

                            $(".movie-caption-" + (key + 1)).html(captionData);
                            //$(".carousel-indicators").append(carouselIndicators);

                        },
                        error: function (x) {
                            console.log(x.status);
                        }
                    });
                    //Other properties acquisition ends here

                }


            });

            //console.log(data);
        },
        error: function (x) {
            console.log(x.status);
            $("#movies-slide").html("<h3>Please connect to the internet to get movie data. Movie data cannot be found</h3>")
        }
    });
});