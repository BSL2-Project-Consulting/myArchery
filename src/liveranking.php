<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="liveranking.js"></script>
    <title>Live Ranking</title>

    <?php
                 $db = mysqli_connect('localhost', 'root', 'test1234', 'myarchery') or die("could't connect to database");              
                 

                  $user_check_query = "SELECT username FROM user ";
                  $results = mysqli_query($db, $user_check_query);
                  $temp = array();
                 while($db_output = mysqli_fetch_assoc($results))
                 {
                  $temp[] = $db_output['username'];
                  
                 }

                
                  
                 
                 

                 
                
                 
                 
             ?>

             
    

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
          <td>
          <script>
      
      document.write(<?php echo json_encode($temp[1]); ?>);
            </script>
          </td>
          <td>
            <script>
              var punktetier1 = 1;
              document.write(punktetier1);
              </script>
          </td>
          <td>
          <script>
              </script>
          </td>
          <td>2</td>
         </tr>
         <tr>
           <td>Rank2</td>
           <td>
           <script>
      
      document.write(<?php echo json_encode($temp[0]); ?>);
            </script>
             
          </td>
           <td>2</td>
           <td>1</td>
           <td>3</td>
         </tr>
         <tr>
            <td>Rank3</td>
            <td>
            <script>
      
      document.write(<?php echo json_encode($temp[2]); ?>);
            </script>
            </td>
            <td>3</td>
            <td>2</td>
            <td>1</td>
          </tr>
      </table>
        

             
</body>


</html>

 