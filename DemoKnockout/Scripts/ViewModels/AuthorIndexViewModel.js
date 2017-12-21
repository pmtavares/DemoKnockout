function AuthorIndexViewModel(authors) {
    var self = this;
    self.authors = authors;
    self.showDeleteModal = function (data, event) {
        self.sending = ko.observable(false);

        $.get($(event.target).attr('href'), function (d) {
            
            $('.body-content').prepend(d);
            $('#deleteModal').modal('show');
            ko.applyBindings(self, document.getElementById('deleteModal'));
        });
    };

    self.deleteAuthor = function (form) {
        
        self.sending(true);
        return true;
    }

}