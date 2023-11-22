pipeline {
    agent {
        dockerfile {
            filename 'Dockerfile'
            dir './'
            args '-it --entrypoint=dotnet StudentsApp.dll'
        }
    }
    stages {
        stage('Build') {
            steps {
                sh '''
                    pwd
                    cd ./StudentsApp
                    cd ./StudentsApp
                    ls -la
                '''
                echo "Building"
            }
        }
    }
}
