pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
            }
        }
        stage('Test') {
		steps {
			script {
				properties ([
					parameters ([
						choice(
							choices: ['ONE', 'TWO'],
							name: 'PARAMETER_01'
						),
						booleanParam(
							defaultValue: true,
							description: '',
							name: 'BOOLEAN'
						),
						text(
							defaultValue: '''
							this is a multine
							string
							''',
							name: 'MULTI-LINE-STRING'
						),
						string(
							defaultValue: 'scriptcrunch',
							name: 'STRING-PARAMETER',
							trim: true

						)
					])
				])
			}
			echo 'Testing ${BOOLEAN}'
		}
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}