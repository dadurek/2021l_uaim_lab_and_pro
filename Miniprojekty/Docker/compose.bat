docker-compose -f docker-compose-lab.yml up -d
timeout /t 20

curl -X GET "https://localhost:5001/examination-rooms-selection" -H  "accept: text/plain"
curl -X POST "https://localhost:5001/add-doctor" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"FirstName\":\"Michal\",\"LastName\":\"Jakis\",\"Sex\":\"male\",\"Specializations\":[1,5]}"
curl -X POST "https://localhost:5001/add-room" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"Number\":\"99a\",\"Certifications\":[1,5]}"
curl -X GET "https://localhost:5001/examination-rooms-selection" -H  "accept: text/plain"