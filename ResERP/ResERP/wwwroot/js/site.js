﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () => {
    const detailButtons = document.querySelectorAll('.detail-button');

    detailButtons.forEach(button => {
        button.addEventListener('click', function () {
            //Get User Email
            const email = this.getAttribute('data-email');

            // Call Partial View 
            fetch(`/Main/GetUserDetail?email=${email}`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.text();
                })
                .then(html => {
                    // Update Data
                    document.querySelector('#modalContent').innerHTML = html;
                })
                .catch(error => {
                    console.error('There was a problem with the fetch operation:', error);
                });
        });
    });
});

