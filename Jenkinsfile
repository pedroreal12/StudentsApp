pipeline {
    agent {
        dockerfile {
            filename 'Dockerfile'
                dir './'
                args '-it --entrypoint="dotnet StudentsApp.dll"'
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
        stage('Run') {
            agent {
                docker {
                    image 'projcs-server'
                    label 'projcs-server'
                }
            }
            steps{
                sh '''
                    ls -al
                '''
            }
        }
    }
}
