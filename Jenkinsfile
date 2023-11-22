pipeline {
    agent any
    stages {
        stage('Initializing') {
            steps {
                sh '''
                    pwd
                    cd ./StudentsApp
                    cd ./StudentsApp
                    ls -la
                    
                '''
            }
        }
        stage('Build') {
            agent {
                dockerfile {
                    filename 'Dockerfile'
                        dir './'
                        args '-it --entrypoint="dotnet StudentsApp.dll"'
                }
            }
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
