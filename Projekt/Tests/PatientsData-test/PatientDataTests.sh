curl -X GET "https://localhost:5001/patients" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/select-condition?type=1" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/select-condition?type=2" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/select-condition?type=3" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/patient-id?Id=1" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/patient-id?Id=2" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/patient-id?Id=3" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/patient-id?Id=4" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/patient-pesel?pesel=68329018173" -H  "accept: text/plain" --insecure 
curl -X GET "https://localhost:5001/patient-pesel?pesel=86392074438" -H  "accept: text/plain" --insecure
curl -X GET "https://localhost:5001/patient-pesel?pesel=86392074438" -H  "accept: text/plain" --insecure
curl -X POST "https://localhost:5001/add-patient" -H  "accept: */*" -H  "Content-Type: application/json-patch+json" -d "{\"id\":51,\"name\":\"Pawel Bodenko\",\"sex\":\"Male\",\"pesel\":\"12312312312\",\"conditions\":[{\"type\":10,\"diagnosisDate\":\"1971-12-01T00:00:00\"},{\"type\":15,\"diagnosisDate\":\"1971-12-01T00:00:00\"}]}" --insecure
curl -X POST "https://localhost:5001/add-patient" -H  "accept: */*" -H  "Content-Type: application/json-patch+json" -d "{\"id\":52,\"name\":\"Agnieszka Bodenko\",\"sex\":\"Female\",\"pesel\":\"12312312312\",\"conditions\":[{\"type\":6,\"diagnosisDate\":\"1971-12-01T00:00:00\"},{\"type\":17,\"diagnosisDate\":\"1971-12-01T00:00:00\"}]}" --insecure
curl -X POST "https://localhost:5001/add-patient" -H  "accept: */*" -H  "Content-Type: application/json-patch+json" -d "{\"id\":53,\"name\":\"Rafal Kowal\",\"sex\":\"Male\",\"pesel\":\"12312312312\",\"conditions\":[{\"type\":15,\"diagnosisDate\":\"1971-12-01T00:00:00\"},{\"type\":15,\"diagnosisDate\":\"1971-12-01T00:00:00\"}]}" --insecure
PAUSE
 
