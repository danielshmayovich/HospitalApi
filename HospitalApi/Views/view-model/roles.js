function RolesController($scope, $http)
{
    $http.get('/api/roles/all').then(function(response)
    {
        //console.log(response.data);

        var map = {}; // this is my map

        for (var i in response.data) // for every role in roles
        {
            // store the role id as my map item - key
            // store the role title as the item - value
            // map item == kvp -> key value pair
            map[response.data[i].Id] = response.data[i].Title;
        }

        //console.log(map);
        //console.log(map[103]);

        $scope.roles = response.data;
        $scope.rolesMap = map;
    });
}