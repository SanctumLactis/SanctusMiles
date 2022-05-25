from flask import Blueprint, session as user_session, render_template, redirect, url_for

from app import app, Session, view_metric
from app.components import orm
from app.components.utils import exception_str, apply_metrics
from app.components.cipher import AESCipher


mod = Blueprint("docs", __name__, url_prefix="/docs")

cipher = AESCipher()


@apply_metrics(endpoint="/docs/")
@mod.route("/")
def index():
    return redirect(url_for("index.index"))


@apply_metrics(endpoint="/docs/eldin")
@mod.route("/eldin")
def eldin():
    return render_template("docs/eldin.html")


@apply_metrics(endpoint="/docs/geir")
@mod.route("/geir")
def geir():
    return render_template("docs/geir.html")


@apply_metrics(endpoint="/docs/jens")
@mod.route("/jens")
def jens():
    return render_template("docs/jens.html")


@apply_metrics(endpoint="/docs/jonas")
@mod.route("/jonas")
def jonas():
    return render_template("docs/jonas.html")
