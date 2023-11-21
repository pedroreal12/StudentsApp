pipeline {
    agent { dockerfile true }
    stages {
        stage('Teste') {
            steps {
                sh "cd ./StudentsApp/app"
                sh "dotnet StudentsApp.dll"
            } 
        }
    }
}
