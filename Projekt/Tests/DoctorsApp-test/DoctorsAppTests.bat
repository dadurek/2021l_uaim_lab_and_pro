curl -X GET "https://localhost:5003/patients" -H  "accept: text/plain"
curl -X GET "https://localhost:5003/patient/1" -H  "accept: text/plain"
curl -X GET "https://localhost:5003/patient/condition/1" -H  "accept: text/plain"
curl -X GET "https://localhost:5003/patient/pesel/83978898013" -H  "accept: text/plain"
curl -X POST "https://localhost:5003/patient" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":100,\"name\":\"Rafal Pawel\",\"sex\":\"Male\",\"pesel\":\"123123\",\"conditions\":[{\"type\":50,\"diagnosisDate\":\"2021-04-12T11:55:22.346Z\"}]}"

curl -X GET "https://localhost:5003/doctors" -H  "accept: text/plain"
curl -X GET "https://localhost:5003/doctor/1" -H  "accept: text/plain"
curl -X GET "https://localhost:5003/doctor/specialization/1" -H  "accept: text/plain"
curl -X GET "https://localhost:5003/doctor/pesel/81135616794" -H  "accept: text/plain"
curl -X POST "https://localhost:5003/doctor" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":100,\"name\":\"Rafal Pawel\",\"sex\":\"Female\",\"pesel\":\"536\",\"specializations\":[{\"type\":75,\"certificationDate\":\"2021-04-12T11:56:59.816Z\"}]}"
curl -X GET "https://localhost:5003/doctor/1/can-treat" -H  "accept: text/plain"
curl -X GET "https://localhost:5003/doctor-patient-matches" -H  "accept: text/plain"

PAUSE