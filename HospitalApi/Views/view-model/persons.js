function PersonsController($scope, $http)
{
    $scope.refreshData = function()
    {
        $http.get('/api/persons/all', { cache: false }).then(function (response)
        {
            //console.log(response.data);

            $scope.persons = response.data;
        });
    };

    $scope.setCurrentPerson = function(person)
    {
        //console.log(person)
        $scope.currentPerson = person;
    };

    $scope.insertPerson = function ()
    {
        $http.post('/api/persons/add', $scope.newPerson).then(function (response)
        {
            $scope.resetNewPerson();
            $scope.refreshData();
        });
    };

    $scope.updatePerson = function()
    {
        $http.post('/api/persons/edit', $scope.currentPerson).then(function (response)
        {
            $scope.refreshData();
        });

        delete $scope.currentPerson;
    };

    $scope.deletePerson = function ()
    {
        $http.post('/api/persons/remove', $scope.currentPerson.Id).then(function (response)
        {
            $scope.refreshData();
        });

        delete $scope.currentPerson;
    };

    $scope.resetNewPerson = function ()
    {
        $scope.newPerson = {};
    };

    $scope.resetNewPerson();
    $scope.refreshData();
}