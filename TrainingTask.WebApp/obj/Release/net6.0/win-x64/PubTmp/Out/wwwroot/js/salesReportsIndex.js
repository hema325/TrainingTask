





$(function () {

    let pageNumber = 1;
    const pageSize = 10;

    function addItems(items) {
        for (let i = 0; i < items.length; ++i)
            $("table tbody").append(`
             <tr>
                <td>${items[i].number}</td>
                <td>${items[i].clientName}</td>
                <td>${items[i].itemName}</td>
                <td>${new Date(items[i].date).toDateString()}</td>
                <td>${items[i].price}</td>
                <td>${items[i].quantity}</td>
                <td>${items[i].total}</td>
                <td>${Number(items[i].discount)}%</td>
                <td>${items[i].theNet}</td>
                <td>${Number(items[i].paidUp)}</td>
                <td>${items[i].theRest}</td>
             </tr>
            `)
    }

    function loaderOn() {
        $("#loader").removeClass("d-none");
    }

    function loaderOff() {
        $("#loader").addClass("d-none")
    }

    let from;
    let to;

    function load() {

        let tableBody = $("table tbody").empty();

        $.ajax({
            url: `/salesReports/get?page=${pageNumber}&size=${pageSize}&from=${from}&to=${to}`,
            type: "get",
            success: function (paginatedList) {

                loaderOff();
                addItems(paginatedList.items);
                tableBody.fadeOut(0).fadeIn("slow");

                if (paginatedList.hasPreviousPage)
                    $("#prev").removeClass("d-none").fadeOut(0).fadeIn("fast");
                else
                    $("#prev").fadeOut("fast");

                if (paginatedList.hasNextPage)
                    $("#next").removeClass("d-none").fadeOut(0).fadeIn("fast");
                else
                    $("#next").fadeOut("fast");

            },
            error: function () {
                toastr.error('Failed To Load The Data');
                loaderOff();
            }
        })
    }

    $("form").submit(function () {
        pageNumber = 1;
        from = $('form input[name="From"]').val();
        to = $('form input[name="To"]').val();

        if (from != '' && to != '') {
            loaderOn();
            load();
        }

        return false;
    })

    $("#prev").click(function () {
        --pageNumber;
        loaderOn();
        load();

    })

    $("#next").click(function () {
        ++pageNumber;
        loaderOn();
        load();
    })

})

