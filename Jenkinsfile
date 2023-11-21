pipeline {
    agent { dockerfile true }
    stages {
        stage('Teste') {
            steps {

                sh "dotnet run --urls http://localhost:5000"
            } 
        }
    }
}
