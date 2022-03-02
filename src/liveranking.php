<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="liveranking.js"></script>
    <title>Live Ranking</title>
    <script>
        
'var name = <?php echo json_encode($name); ?>;

      </script>

</head>
<body>
  


    <table>
        <tr>
          <th></th>
          <th>Name</th>
          <th>Tier1</th>
          <th>Tier2</th>
          <th>Tier3</th>
          <th>Zwischenpunkte</th>
        </tr>
        <tr>
          <td>Rank1</td>
          <td>Spieler2</td>
          <td>1</td>
          <td>3</td>
          <td>2</td>
         </tr>
         <tr>
           <td>Rank2</td>
           <td>
             
             
          </td>
           <td>2</td>
           <td>1</td>
           <td>3</td>
         </tr>
         <tr>
            <td>Rank3</td>
            <td></td>
            <td>3</td>
            <td>2</td>
            <td>1</td>
          </tr>
      </table>
        

             <?php
             
             session_start();
             $db = mysqli_connect('localhost', 'root', 'test1234', 'myarchery') or die("could't connect to database");
 
             $user_check_query = "SELECT username FROM user;";
            
 
             ?>
</body>


</html>

 