pipeline {
    agent { dockerfile true }
    stages {
        stage('Build') {
            steps {
                sh '''
                    echo "Running"
                    cd ./StudentsApp/app
                    dotnet StudentsApp.dll
                '''
            } 
        }
    }
}
