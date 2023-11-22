pipeline {
    agent {
        dockerfile {
            filename 'Dockerfile'
            dir './'
            args '-it --entrypoint='
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
