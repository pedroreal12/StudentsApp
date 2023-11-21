pipeline {
    agent none
    stages {
        stage('Running') {
            agent {dockerfile true}
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
