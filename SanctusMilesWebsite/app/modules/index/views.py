from flask import Blueprint, render_template, redirect, url_for
from prometheus_client import generate_latest

from app.components.utils import apply_metrics

mod = Blueprint("index", __name__, url_prefix="/")


@apply_metrics(endpoint="/")
@mod.route("/")
def index():
    return render_template("index.html")


@apply_metrics(endpoint="/home")
@mod.route("/home")
def home(user):
    return redirect(url_for("index.index"))


@apply_metrics(endpoint="/metrics")
@mod.route("/metrics")
def metrics():
    return generate_latest()
