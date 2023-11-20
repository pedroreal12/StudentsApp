pipeline {
    agent {
        docker {image "mcr.microsoft.com/dotnet/aspnet:6.0-alpine"}
    }
    stages {
        stage('Teste') {
            steps {

                sh "dotnet run --urls http://localhost:5000"
            } 
        }
    }
}
