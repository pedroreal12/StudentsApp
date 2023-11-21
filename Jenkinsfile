pipeline {
    agent { dockerfile true }
    stages {
        stage('Teste') {
            steps {
                sh "cd ./app"
                sh "dotnet StudentsApp.dll"
            } 
        }
    }
}
