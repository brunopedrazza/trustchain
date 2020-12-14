import React, { Component } from "react";
import { Link, withRouter } from "react-router-dom";

import api from "../../services/api";
import { login } from "../../services/auth";

import { Form, Container } from "./styles";

class SignIn extends Component {
    state = {
        user: "",
        password: "",
        error: ""
    };

    handleSignIn = async e => {
        e.preventDefault();
        const { user, password } = this.state;
        if (!user || !password) {
            this.setState({ error: "Preencha usuário e senha para continuar!" });
        } else {
            try {
                if (user == "admin" && password == "password") {
                    var fakeToken = makeid(50);
                    console.log(fakeToken);
                    const response = {
                        "data": {
                            "token": fakeToken
                        }
                    };
                    login(response.data.token);
                    this.props.history.push("/app");
                }
                else {
                    throw "Invalid user or password";
                }
            } catch (err) {
                this.setState({
                    error:
                        "Houve um problema com o login, verifique suas credenciais."
                });
            }
        }
    };

    render() {
        return (
            <Container>
                <Form onSubmit={this.handleSignIn}>
                    {this.state.error && <p>{this.state.error}</p>}
                    <input
                        type="user"
                        placeholder="Usuário"
                        onChange={e => this.setState({ user: e.target.value })}
                    />
                    <input
                        type="password"
                        placeholder="Senha"
                        onChange={e => this.setState({ password: e.target.value })}
                    />
                    <button type="submit">Entrar</button>
                </Form>
            </Container>
        );
    }
}

function makeid(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
}

export default withRouter(SignIn);