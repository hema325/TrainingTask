

$(function () {

    let pageNumber = 1;
    const pageSize = 5;

    function addItems(items) {
        for (let i = 0; i < items.length; ++i) {
            $("table tbody").append(`
             <tr>
                <td>${items[i].name}</td>
                <td class=" text-wrap">${items[i].notes != null ? items[i].notes.substr(0, 50) + (items[i].notes.length > 50 ?" . . .":"") : items[i].notes}</td >
                <td>
                    <a href="companies/details/${items[i].id}" class="btn btn-secondary p-1">Details</a>
                    <a href="companies/edit/${items[i].id}" class="btn btn-primary p-1">Edit</a>
                    <button id="${items[i].id}" class="btn btn-danger p-1">Delete</button>
                </td>
             </tr>
            `)

            $(`#${items[i].id}`).click(function () {
                let companyId = $(this).attr("id");
                swal({
                    title: "Are you sure?",
                    text: "Once deleted, you will not be able to restore this company!",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                })
                    .then((willDelete) => {
                        if (willDelete) {
                            $.ajax({
                                url: `/companies/delete/${companyId}`,
                                type: "delete",
                                success: function () {
                                    swal("Poof! Your company field has been deleted!", {
                                        icon: "success",
                                    });
                                    $(`#${companyId}`).parent().parent().hide("fast");
                                },
                                error: function () {
                                    swal("Failed to deleted the company field", {
                                        icon: "error",
                                    });
                                }
                            })
                           
                        } else {
                            swal("Your company field is safe!");
                        }
                    });
            })
        }
    }

    function loaderOn() {
        $("#loader").removeClass("d-none");
    }

    function loaderOff() {
        $("#loader").addClass("d-none")
    }

    function load() {

        let tableBody = $("table tbody").empty();

        $.ajax({
            url: `/companies/get?page=${pageNumber}&size=${pageSize}`,
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

    loaderOn();
    load();

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

