pipeline {
    agent {dockerfile true}
    stages {
        stage('Build') {
            steps {
                sh '''
                    pwd
                    cd ./StudentsApp
                    cd ./StudentsApp
                    ls -la
                    dotnet --list-sdks 
                '''
                echo "Building"
            }
        }
    }
}
