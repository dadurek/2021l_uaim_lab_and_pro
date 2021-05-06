docker-compose -f docker-compose-lab.yml up -d
timeout /t 20

curl -X GET "https://localhost:44328/examination-rooms-selection" -H  "accept: text/plain"
curl -X POST "https://localhost:44328/add-doctor" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"FirstName\":\"Michal\",\"LastName\":\"Jakis\",\"Sex\":\"male\",\"Specializations\":[1,5]}"
curl -X POST "https://localhost:44328/add-room" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"Number\":\"99a\",\"Certifications\":[1,5]}"
curl -X GET "https://localhost:44328/examination-rooms-selection" -H  "accept: text/plain"