(function (dtsProject, $, undefined) {

    // public configuration variable
    dtsProject.config = { gameId: null, gameInfo: null, designerInfo: null };

    // bind events and such to the DOM
    // private function
    function bindEvents() {
        dtsProject.config.gameId = $('#thegamecrafterid').val();
    }

    function getGameCrafterInfo() {
        var url = "https://www.thegamecrafter.com/api/game/" + dtsProject.config.gameId;

        if (dtsProject.config.gameId != null) {
            $.ajax({
                url: url
                , data: { "_include_relationships": "1" }
            })
                .done(function (data) {
                    dtsProject.config.gameInfo = data.result;

                    // display any information we want from the gamecrafter
                    showGameInfo('gameInfo', 'audience', $('.js-project-desc'), true, 'Audience:', true);
                    showGameInfo('gameInfo', 'primary_mechanic', $('.js-project-desc'), true, 'Primary Mechanic:');
                    showGameInfo('gameInfo', 'play_time', $('.js-project-desc'), true, 'Play Time:');
                    showGameInfo('gameInfo', 'date_published', $('.js-project-desc'), true, 'Publish Date:');
                    showGameInfo('gameInfo', 'price', $('.js-project-desc'), true, 'Price:');
                    showGamePlayers($('.js-project-desc'));

                    getGameCrafterDesignerInfo(dtsProject.config.gameInfo.designer_id);

                    showGameInfo('gameInfo', 'description_html', $('.js-project-desc'));

                    getGameDownloads(dtsProject.config.gameId);
                    getGameImages(dtsProject.config.gameId);

                })
                .fail(function (err) {
                    try {
                        console.log(err);
                    } catch (ex) { };
                });
        }
    }

    function getGameCrafterDesignerInfo(designerId) {
        var url = "https://www.thegamecrafter.com/api/designer/" + designerId;

        $.ajax(url)
            .done(function (data) {
                dtsProject.config.designerInfo = data.result;

                // display any information we want from the gamecrafter                
                showDesignerInfo($('.js-project-desc'));
            })
            .fail(function (err) {
                try {
                    console.log(err);
                } catch (ex) { };
            });
    }

    // draw some game information at a specific element
    function showGameInfo(data, dataName, $elem, wrap, label, overwrite) {
        var dataItem = 'dtsProject.config.' + (data || 'gameInfo') + '.' + dataName;
        var itemText = eval(dataItem);

        itemText = '<p><b>' + (label || '') + ' </b>' + itemText + '</p>';

        if (overwrite) {
            $elem.html(itemText);
        }
        else {
            $elem.append(itemText);
        }
    }

    function showGamePlayers($elem) {
        var min = dtsProject.config.gameInfo.min_players;
        var max = dtsProject.config.gameInfo.max_players;
        var itemText = '<p><b>Players: </b>' + min + ' to ' + max + '</p>';
        $elem.append(itemText);
    }

    function showDesignerInfo($elem) {
        var name = dtsProject.config.designerInfo.name;
        var url = dtsProject.config.designerInfo.shop_uri;
        var itemText = '<p><b>Designer: </b><a href="https://www.thegamecrafter.com' + url + '" target="_blank">' + name + '</a></p>';

        $elem.append(itemText);

        $('.js-designer-desc').remove();
    }

    // display any download items associated with this game
    function getGameDownloads(gameId) {
        var url = "https://www.thegamecrafter.com/api/game/" + gameId + "/downloads";

        $.ajax(url)
            .done(function (data) {
                if (data.result.items.length > 0) {
                    var h = "<p><div><b>Game Downloads</b></div><ul>";

                    $.each(data.result.items, function (index, item) {
                        h += "<li><a href='" + item.file.file_uri + "' target='_blank'>" + item.file.name + "</a></li>";
                    });

                    h += "</ul></p>";

                    $('.js-project-desc').append(h);
                }
            })
            .fail(function (err) {
                try {
                    console.log(err);
                } catch (ex) { };
            });
    }

    function getGameImages(gameId) {
        var url = "https://www.thegamecrafter.com/api/game/" + gameId + "/actionshots";

        $.ajax(url)
            .done(function (data) {
                if (data.result.items.length > 0) {
                    var h = "<p><b>Action Shots</b>";
                    h += "<div class='flexslider'><ul class='slides'>";

                    $.each(data.result.items, function (index, item) {
                        h += '<li class="item" data-thumb="' + item.image.preview_uri + '"><img src="' + item.image.file_uri + '" alt="' + item.image.object_name + '"></li>';
                    });

                    h += "<ul></div></p>";

                    $('.js-project-desc').append(h);


                    $('.flexslider').flexslider({
                        animation: "slide",
                        controlNav: "thumbnails",
                        smoothHeight: true
                    });

                }
            })
            .fail(function (err) {
                try {
                    console.log(err);
                } catch (ex) { };
            });
    }

    //initialize object
    // this is a public function
    dtsProject.init = function () {
        bindEvents();

        // get game info from the gamecrafter
        getGameCrafterInfo();
    }
})(window.dtsProject = window.dtsProject || {}, jQuery);

// self initilize once the DOM is loaded
(function ($) {
    dtsProject.init();
}(jQuery));