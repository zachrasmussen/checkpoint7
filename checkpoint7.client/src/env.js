export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'http://localhost:5001' : ''
export const useSockets = false
export const domain = 'zachras.us.auth0.com'
export const audience = 'https://codeworksclassroom.com'
export const clientId = 'kVOf6nNdaPFviJ6C3jPvC9xsfVp6DE4N'
